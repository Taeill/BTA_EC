using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms.Impl;

public class Ultim : MonoBehaviour
{
    [SerializeField] bool _inputUltime = false;
    [SerializeField] LayerMask _middleMask;
    [SerializeField] Transform _middlePosition;
    [SerializeField] float _radius;
    [Header("ANIMATOR")]
    [SerializeField] Animator _animator;
    [SerializeField] string _UltimName;


    public void Ultime(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                _inputUltime = true;

                if (_inputUltime == true && GameManager.instance.Score >= 50)
                {
                    _animator.SetTrigger(_UltimName);
                    Debug.Log("Ultim");
                    _inputUltime = false;
                    GameManager.instance.SuppScore();
                    TableauRecastCircle();
                }
                break;
            case InputActionPhase.Canceled:
                _inputUltime = false;
                break;
            default:
                break;
        }




    }

    private void TableauRecastCircle()
    {
        Collider2D[] allContact = Physics2D.OverlapCircleAll(_middlePosition.position, _radius, _middleMask);

        if (allContact.Length > 0)
        {
            foreach (Collider2D el in allContact)
            {

                var h = el.attachedRigidbody.GetComponent<Health>();

                if (h != null)
                {
                    el.attachedRigidbody.GetComponent<Health>().TakeDomage(3);
                }


            }
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_middlePosition.position, _radius);
    }
}
