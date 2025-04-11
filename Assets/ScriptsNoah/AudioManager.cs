using UnityEngine;
using FMODUnity;
using FMOD.Studio;

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

        Debug.LogWarning("Sound " + soundName + " not found in FMODSoundManager");
    }

    public void PlaySound(EventReference eventRef, Vector3 position = default)
    {
        RuntimeManager.PlayOneShot(eventRef, position);
    }
}