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
        if (_objectToDestroy.GetComponent<Enemy_Behavior>().BossSpawned)
        {
            _objectToDestroy.GetComponent<Enemy_Behavior>().Owner._spawnedObj.RemoveAt(_objectToDestroy.GetComponent<Enemy_Behavior>().OwnerListIndex);
        }
        if (_objectToDestroy == gameObject.transform.root.CompareTag("Player"))
        {
            SceneManager.LoadScene("GameOver");
        }
        Destroy(_objectToDestroy);
        return;
        
    }
   
}