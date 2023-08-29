using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class Ultim : MonoBehaviour
{
    [SerializeField] bool _inputUltime = false;

    public void Ultime(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                _inputUltime = true;
                break;
            case InputActionPhase.Canceled:
                _inputUltime = false;
                break;
            default:
                break;
        }

        if (_inputUltime == true && GameManager.instance.Score >= 50)
        {
            Debug.Log("Ultim");
            _inputUltime = false;

            GameManager.instance.SuppScore();
            
        }
    }
}
