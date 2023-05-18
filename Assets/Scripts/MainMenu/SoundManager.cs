using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource soundEffectSource;
    public AudioSource musicSource;

    public AudioClip menuMusic;
    public AudioClip gameMusic;

    public AudioClip keyPressSound;
    public AudioClip collisionSound;

    private void Awake()
    {
        // Make sure there's only one instance of SoundManager
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        // Don't destroy this object when a new scene loads
        DontDestroyOnLoad(gameObject);

        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;

        // Play the appropriate music depending on the initial scene
        OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
    }

    private void OnDestroy()
    {
        // Unsubscribe from the sceneLoaded event
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void PlaySoundEffect(AudioClip clip)
    {
        soundEffectSource.clip = clip;
        soundEffectSource.Play();
    }

    public void PlayMusic(AudioClip clip)
    {
        // If the same music is already playing, don't play it again
        if (musicSource.clip == clip && musicSource.isPlaying)
        {
            return;
        }

        musicSource.clip = clip;
        musicSource.Play();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Play the appropriate music depending on the scene
        if (scene.name == "MainMenu")
        {           
            PlayMusic(menuMusic);
        }
        else if (scene.name == "GameScene")
        {
            PlayMusic(gameMusic);
        }
    }
}
