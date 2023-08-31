using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeathAnimationEvent : MonoBehaviour
{
    [SerializeField] Health _death;
    
    public void DeathTime()
    {
        
        Destroy(gameObject);
      
    }

}