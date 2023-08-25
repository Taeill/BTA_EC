using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    [SerializeField] float _roamingAreaSize = 10;
    [SerializeField] Rigidbody2D _rgbd2d;
    [SerializeField] Animator _Animator;

    private bool _playerInRange = false;
    private bool _currentGoalDone = true;
    private bool _currentWaitDone = true;
    private Vector3 _currentGoal;
    private Vector2 _startPos;



    Vector2 _playerVelocity
    {
        get { return _rgbd2d.velocity; }
        set
        {
            _rgbd2d.velocity = value;
            _Animator.SetFloat("Velocity", value.magnitude);
            if (value.x >= 0.1) 
            {
                transform.root.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));  
            }
            else if (value.x <= 0.1)
            {
                transform.root.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

    private void Start()
    {
        _startPos = transform.position;
    }

    private void Update()
    {
        if (_playerInRange) // Chase And Fight Behavior
        {

        }
        else if (!_playerInRange) //Idle Routine
        {
            if (_currentGoalDone && _currentWaitDone)
            {
                _currentGoalDone = false;
                _currentWaitDone = false;
                GoTo(FindLocation()); 
            }
            if (Vector3.Distance(transform.position, _currentGoal) <= 1 && !_currentGoalDone)
            {
                _playerVelocity = Vector3.zero;
                StartCoroutine(RandomWaitBetweenWalk());
                _currentGoalDone = true;
            }
        }
        
    }
    

    Vector2 FindLocation()
    {
        _currentGoal = _startPos + (Random.insideUnitCircle * _roamingAreaSize);
        return _currentGoal;
    }

    void GoTo(Vector2 a)
    {
        _playerVelocity = (new Vector3 (a.x,a.y,0) - transform.position).normalized;
    }

    IEnumerator RandomWaitBetweenWalk()
    {
        yield return new WaitForSeconds(Random.Range(1,5));
        _currentWaitDone = true;
    }
}
