using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapMusic : MonoBehaviour
{
    // Reference to the SoundManager
    public SoundManager soundManager;

    // The background music
    public AudioClip backgroundMusic;

    // The additional sound effect
    public AudioClip additionalSoundEffect;

    // The volume for background music (in percentage)
    public float backgroundMusicVolume = 0.5f;

    // The volume for additional sound effect (in percentage)
    public float additionalSoundEffectVolume = 0.5f;

    private AudioSource backgroundMusicSource;
    private AudioSource additionalSoundEffectSource;

    // Start is called before the first frame update
    void Start()
    {
        // Get the AudioSource components
        backgroundMusicSource = soundManager.gameObject.AddComponent<AudioSource>();
        additionalSoundEffectSource = soundManager.gameObject.AddComponent<AudioSource>();

        // Play the background music
        PlayBackgroundMusic();

        // Play the additional sound effect
        PlayAdditionalSoundEffect();
    }

    // Play the background music
    void PlayBackgroundMusic()
    {
        backgroundMusicSource.clip = backgroundMusic;
        backgroundMusicSource.volume = backgroundMusicVolume;
        backgroundMusicSource.loop = true;
        backgroundMusicSource.Play();
    }

    // Play the additional sound effect
    void PlayAdditionalSoundEffect()
    {
        additionalSoundEffectSource.clip = additionalSoundEffect;
        additionalSoundEffectSource.volume = additionalSoundEffectVolume;
        additionalSoundEffectSource.loop = true;
        additionalSoundEffectSource.Play();
    }
}
