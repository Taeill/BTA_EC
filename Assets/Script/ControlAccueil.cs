using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlAccueil : MonoBehaviour
{
    // Start is called before the first frame update
   public void ChangeScene(string _sceneName)
    {
        SceneManager.LoadScene( _sceneName );
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Menu(string _menuName)
    {
        SceneManager.LoadScene(_menuName);
    }
}
