using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{

    [SerializeField] Animator _animator;
    bool isWin = false;
    // Start is called before the first frame update
    void Start()
    {
        isWin = true;
        _animator.SetBool("win", true);
    }

}
