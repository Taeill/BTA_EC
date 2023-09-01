using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    [SerializeField] GameObject _target;
    [SerializeField] Animator _animator;


    enum _bossStates
    {
        TargettingState,
        IdleState
    }

    _bossStates _state = _bossStates.IdleState;


    private void Start()
    {
        StartCoroutine(Routine());
    }

    IEnumerator Routine()
    {

        _state = _bossStates.IdleState;
        _animator.SetBool("MusicAttack", false);

        yield return new WaitForSeconds(10);

        _state = _bossStates.TargettingState;
        _animator.SetBool("MusicAttack", true);

        StartCoroutine(Targetting());

        yield return new WaitForSeconds(5);

        StartCoroutine(Routine());
        
    }

    IEnumerator Targetting()
    {
        Instantiate(_target, transform.position, transform.rotation);
        yield return new WaitForSeconds(2);

        if (_state == _bossStates.TargettingState)
        {
            StartCoroutine(Targetting());
        }
        
    }

    void Idling()
    {

    }
}
