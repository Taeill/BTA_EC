using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance
    {

        get; private set;
    }
    
    [SerializeField] int _lifePlayer = 3;


    private void Awake()
    {

        instance = this;
        
    }
    internal void SuppLife(int count)
    {
        _lifePlayer -= count;
      
    }
}
