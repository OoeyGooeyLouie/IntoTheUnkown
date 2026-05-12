using UnityEngine;
using System.Collections.Generic;
 
public class AudioManager : MonoBehaviour
{
    public enum SoundType
    {
        Jump,
        Powerup,
        Shoot,
        enemyAttack,
        Music_Menu,
        Music_Battle
        // Add more sound types as needed
    }
 
    [System.Serializable]
    public class Sound
    {
        public SoundType Type;
        public AudioClip Clip;
 
        [Range(0f, 1f)]
        public float Volume = 1f;
 
        [HideInInspector]
        public AudioSource Source;
    }
 
    //Singleton
    public static AudioManager Instance;
 
    //All sounds and their associated type - Set these in the inspector
    public Sound[] AllSounds;
    public Sound [] EnemyAttackSounds;
 
    //Runtime collections
    private Dictionary<SoundType, Sound> _soundDictionary = new Dictionary<SoundType, Sound>();
    private AudioSource _musicSource;
 
    private void Awake()
    {
        //Assign singleton
        Instance = this;
 
        //Set up sounds
        foreach(var s in AllSounds)
        {
            _soundDictionary[s.Type] = s;
        }
    }
 
 
 
    //Call this method to play a sound
    public void Play(SoundType type)
    {
        //Make sure there's a sound assigned to your specified type
        if (!_soundDictionary.TryGetValue(type, out Sound s))
        {
            Debug.LogWarning($"Sound type {type} not found!");
            return;
        }
 
        //Creates a new sound object
        var soundObj = new GameObject($"Sound_{type}");
        var audioSrc = soundObj.AddComponent<AudioSource>();
 
        //Assigns your sound properties
        audioSrc.clip = s.Clip;
        audioSrc.volume = s.Volume;
 
        //Play the sound
        audioSrc.Play();
 
        //Destroy the object
        Destroy(soundObj, s.Clip.length);
    }

    public void PlayAttack(int index)
    {
        if(index >= EnemyAttackSounds.Length || index < 0)
        {
            Debug.LogWarning("index out of bounds");
            return;
        }
        var sound = EnemyAttackSounds[index];

    if (sound == null)
    {
        Debug.LogWarning($"Sound is NULL at index {index}");
        return;
    }

    if (sound.Clip == null)
    {
        Debug.LogWarning($"Clip is NULL at index {index}");
        return;
    }
        
            //Creates a new sound object
        var soundObj = new GameObject($"Sound_{index}");
        var audioSrc = soundObj.AddComponent<AudioSource>();

        //Assigns your sound properties
        audioSrc.clip = EnemyAttackSounds[index].Clip;
        audioSrc.volume = EnemyAttackSounds[index].Volume;
 
        //Play the sound
        audioSrc.Play();
 
        //Destroy the object
        Destroy(soundObj, EnemyAttackSounds[index].Clip.length);
        
    }
 
    //Call this method to change music tracks
    public void ChangeMusic(SoundType type)
    {
        if (!_soundDictionary.TryGetValue(type, out Sound track))
        {
            Debug.LogWarning($"Music track {type} not found!");
            return;
        }
 
        if (_musicSource == null)
        {
            var container = new GameObject("SoundTrackObj");
            _musicSource = container.AddComponent<AudioSource>();
            _musicSource.loop = true;
        }
 
        _musicSource.clip = track.Clip;
        _musicSource.Play();
    }

    public void StopMusic()
{
    if (_musicSource != null && _musicSource.isPlaying)
    {
        _musicSource.Stop();
    }
}
public void SetMusicVolume(float volume)
{
    if (_musicSource != null)
    {
        _musicSource.volume = volume;
    }
}
    
}