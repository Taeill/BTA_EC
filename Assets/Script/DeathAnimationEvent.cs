using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DeathAnimationEvent : MonoBehaviour
{
    [SerializeField] GameObject _objectToDestroy;
   
    
    public void DeathTime()
    {
        
        Destroy(_objectToDestroy);
        SceneManager.LoadScene("GameOver");

    }

}