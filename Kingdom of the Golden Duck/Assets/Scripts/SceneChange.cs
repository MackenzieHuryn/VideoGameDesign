using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    private string scene;
    public void LoadScene(string sceneName)
    {
        scene = sceneName;
        StartCoroutine(WaitCoroutine(sceneName));
        /*if (!buttonAudio.isPlaying)
        {
            SceneManager.LoadScene(sceneName);
        }
        */
    }

     IEnumerator WaitCoroutine(string sceneName)
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(0.7f);
         SceneManager.LoadScene(sceneName);
    }
}
