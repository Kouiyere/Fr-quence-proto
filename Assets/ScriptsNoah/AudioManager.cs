using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [System.Serializable]
    public class SoundEvent
    {
        public string name;
        public EventReference eventRef;
    }

    public SoundEvent[] soundEvents;

    private Dictionary<string, EventInstance> loopingSounds = new Dictionary<string, EventInstance>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // 🔊 Joue un son one-shot (pas contrôlable)
    public void PlaySound(string soundName, Vector3 position = default)
    {
        foreach (var s in soundEvents)
        {
            if (s.name == soundName)
            {
                RuntimeManager.PlayOneShot(s.eventRef, position);
                return;
            }
        }

        Debug.LogWarning("Sound " + soundName + " not found in AudioManager");
    }

    public void PlayLoopingSound(string soundName, Vector3 position = default)
    {
        if (loopingSounds.ContainsKey(soundName))
        {
            Debug.LogWarning($"Sound '{soundName}' is already playing.");
            return;
        }

        foreach (var s in soundEvents)
        {
            if (s.name == soundName)
            {
                EventInstance instance = RuntimeManager.CreateInstance(s.eventRef);
                instance.set3DAttributes(RuntimeUtils.To3DAttributes(position));
                instance.start();

                loopingSounds.Add(soundName, instance);
                return;
            }
        }

        Debug.LogWarning("Sound " + soundName + " not found in AudioManager");
    }

    // ⏹️ Coupe le son joué via PlayLoopingSound
    public void StopLoopingSound(string soundName)
    {
        if (loopingSounds.TryGetValue(soundName, out EventInstance instance))
        {
            instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            instance.release();
            loopingSounds.Remove(soundName);
        }
        else
        {
            Debug.LogWarning($"Looping sound '{soundName}' not found or already stopped.");
        }
    }

    public bool IsLoopingSoundPlaying(string soundName)
    {
        return loopingSounds.ContainsKey(soundName);
    }
}
