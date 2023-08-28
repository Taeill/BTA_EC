using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

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


    //Constructor
    Vector2 _enemyVelocity
    {
        get { return _rgbd2d.velocity; }
        set
        {
            _rgbd2d.velocity = value;
            _Animator.SetFloat("Speed", value.magnitude*10);
            
            if (value.x >= 0.1) 
            {
                transform.root.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));  
            }
            else if (value.x <= -0.1)
            {
                transform.root.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.transform.root.GetComponent<PlayerMovement>() != null)
        {
            _playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.root.GetComponent<PlayerMovement>() != null)
        {
            _playerInRange = false;
        }
    }

    private void Start()
    {
        _startPos = transform.position;
    }

    private void Update()
    {
        if (_playerInRange) // Chase And Fight Behavior
        {
            

            if (Vector3.Distance(transform.position, PlayerMovement.Instance.transform.position) <= 1)
            {
                _Animator.SetTrigger("Attack");
                _enemyVelocity = Vector3.zero;
            }
            else
            {
                _enemyVelocity = (new Vector3(PlayerMovement.Instance.transform.position.x, PlayerMovement.Instance.transform.position.y, 0) - transform.position).normalized;
            }
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
                _enemyVelocity = Vector3.zero;
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
        _enemyVelocity = (new Vector3 (a.x,a.y,0) - transform.position).normalized;
    }

    IEnumerator RandomWaitBetweenWalk()
    {
        yield return new WaitForSeconds(Random.Range(1,5));
        _currentWaitDone = true;
    }

    void TakeDamage()
    {

    }
}
