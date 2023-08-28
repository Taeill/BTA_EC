using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    [SerializeField] PlayerDomage _playerDomage;

    public void Punching()
    {
        //Debug.Log("Tap");
        _playerDomage.AttackPlayer();
    }
    
}
