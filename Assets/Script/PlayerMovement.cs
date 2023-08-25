using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance
    {
        get;
        private set;
    }

    public Rigidbody2D _rb2d;
    [SerializeField] float _speed;
    //[SerializeField] bool isWalk = false;
    [Header("Animation")]
    [SerializeField] Animator animator;
    [SerializeField] string animationWalk;
    float _horizontalDirection;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("PROBLEM", transform);
        }
    }
    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        var old = _rb2d.velocity;

    }
    public void Move(InputAction.CallbackContext context)
    {
       
        _rb2d.velocity = context.ReadValue<Vector2>() * _speed;

        if (_rb2d.velocity.magnitude > 0)
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }

        if (_rb2d.velocity.x >= 0.1)
        {
            transform.root.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else if (_rb2d.velocity.x <= 0.1)
        {
            transform.root.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }

    }



    public void Count(InputAction.CallbackContext context)
    {


        switch (context.phase)
        {


            case InputActionPhase.Started:

                Debug.Log(" Event Started");
                break;
            case InputActionPhase.Performed:
                Debug.Log("Event Performed");

                break;
            case InputActionPhase.Canceled:

                Debug.Log("Event Canceled");
                break;

        }


    }



}


