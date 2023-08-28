using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDomage : MonoBehaviour
{
    [SerializeField] bool _inputPunch = false;
    [SerializeField] Animator _animator;
    [SerializeField] string _animationPunch;

    List<GameObject> _collidingObject = new List<GameObject>();

    //[SerializeField] float _nextPunchTime=0f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Punch(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                _inputPunch = true;
                break;
            case InputActionPhase.Canceled:
                _inputPunch = false;
                break;
            default:
                break;


        }
        if (_inputPunch == true)
        {
            _animator.SetTrigger("Punch");

        }

    }


    List<GameObject> CheckCollider()
    {
        return _collidingObject;
    }


    //Check la liste de rentree
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _collidingObject.Add(collision.gameObject);
    }
    //Check la list de sortie
    private void OnTriggerExit2D(Collider2D collision)
    {
        _collidingObject.Remove(collision.gameObject);
    }

    public void AttackPlayer()
    {
        if(CheckCollider().Count > 0) 
        {
        foreach(var collider in _collidingObject)
            {
                if(collider.transform.root.GetComponent<Enemy_Behavior>() != null)
                {
                    Debug.Log("Test");
                }
            }
        }
    }
  
}
