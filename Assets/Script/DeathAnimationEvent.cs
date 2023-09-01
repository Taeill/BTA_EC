using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeathAnimationEvent : MonoBehaviour
{
    [SerializeField] GameObject _objectToDestroy;
    
    public void DeathTime()
    {
        
        Destroy(_objectToDestroy);
      
    }

}