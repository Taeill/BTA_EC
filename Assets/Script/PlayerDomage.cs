using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDomage : MonoBehaviour
{
    [SerializeField] bool _inputPunch = false;
    [SerializeField] Animator _animator;
    [SerializeField] string animationPunch;
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
        switch(context.phase) 
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
        if(_inputPunch ==true) 
        {
        _animator.SetTrigger("Punch");
        }
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.attachedRigidbody.CompareTag("Enemi"))
        {
                Debug.Log("Zone");
            
        }
    }
}
