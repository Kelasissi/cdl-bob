using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MusicClass : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioClip _audioClip2;
    

    private void Awake()
    {
        
        DontDestroyOnLoad(transform.gameObject);
        _audioSource = GetComponent<AudioSource>();
        
    }

    void PlayEndMusic()
    {
        _audioSource.clip = _audioClip2;
        _audioSource.Play();
    }

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. 
        //Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {

        if (scene.name == "Aquarium 11")
        {
            Debug.Log("Stopper la Musique de début");
            StopMusic();
            PlayEndMusic();
        }

        if (scene.name == "Aquarium 01")
        {
            StopMusic();
            PlayMusic();
        }
    }

    

public void PlayMusic()
    {
;       if (_audioSource.isPlaying) return;
        _audioSource.Play();
        
        
    }

    public void StopMusic()
    {
        _audioSource.Stop();
    }


}