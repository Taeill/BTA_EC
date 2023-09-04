using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlAccueil : MonoBehaviour
{
    // Start is called before the first frame update
   public void ChangeScene()
    {
        SceneManager.LoadScene("MainScene");
       
        //SceneManager.LoadSceneAsync("MainScene", LoadSceneMode.Additive);
        
        //StartCoroutine(Loading());




    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Menu(string _menuName)
    {
        SceneManager.LoadScene(_menuName);
    }
    IEnumerator Loading()
    {
        yield return SceneManager.UnloadSceneAsync("MainScene");
    }
}
