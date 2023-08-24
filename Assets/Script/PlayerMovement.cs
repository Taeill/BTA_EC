using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance
    {
        get;
        private set;
    }
    
    public Rigidbody2D _rb2d;
    [SerializeField] float _speed ;



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
        //_rbd2.velocity = new Vector2(_horizontalDirection, old.y);

    }
    public void Move(InputAction.CallbackContext context)
    {
        _rb2d.velocity = context.ReadValue<Vector2>() * _speed;
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
