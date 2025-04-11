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
        // Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

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

    public void StopLoop(string soundName)
    {
        if (loopingSounds.TryGetValue(soundName, out EventInstance instance))
        {
            instance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            instance.release();
            loopingSounds.Remove(soundName);
        }
        else
        {
            Debug.LogWarning("Trying to stop loop that is not playing: " + soundName);
        }
    }
}