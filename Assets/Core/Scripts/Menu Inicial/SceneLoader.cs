using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public void LoadSceneByStringInButton(string loadSceneString)
    {
        if (SceneManager.GetActiveScene().ToString() == loadSceneString) { return; }
            StartCoroutine(LoadLevelByString(loadSceneString));
    }
    public void LoadSceneByString(string loadSceneString)
    {
        SceneManager.LoadScene(loadSceneString); 
    }
    public void LoadSceneByInt(int loadSceneInt)
    {
        if (SceneManager.GetActiveScene().buildIndex == loadSceneInt) { return; }
        StartCoroutine(LoadLevelByInt(loadSceneInt));
    }
    IEnumerator LoadLevelByInt(int level)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(level); 
    }
    IEnumerator LoadLevelByString(string level)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(level); 
    }
}
