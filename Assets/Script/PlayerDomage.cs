using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDomage : MonoBehaviour
{
    [SerializeField] bool _inputPunch = false;
    [SerializeField] float _nextPunchTime=0f;


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
                Debug.Log("tap");
                break;
                case InputActionPhase.Canceled:
                _inputPunch = false;
                Debug.Log("NotTap");
                break;
            default:
                break;
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
