using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/**
 * This script plays an audio clip attached to the GameObject's AudioSource
 * component to its full length before loading the scene specified by sceneName.
 * Used to play a button's on-click sound effect before loading a scene.
 */
public class SwitchScene : MonoBehaviour 
{
    AudioSource audioSource;    // Sound to play on button click

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    // Load the scene with the specified sceneName
    public void LoadSceneByName(string sceneName)
    {
        StartCoroutine(DelayLoad(sceneName));       
    }

    // Coroutine allows the button's click sound to play fully before
    // the new scene is loaded and the AudioSource inaccessible
    IEnumerator DelayLoad(string sceneName)
    {
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        SceneManager.LoadScene(sceneName);
    }
}
