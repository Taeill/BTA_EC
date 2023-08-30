using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms.Impl;

public class Ultim : MonoBehaviour
{
    [SerializeField] bool _inputUltime = false;
    [SerializeField] LayerMask _middleMask;
    [SerializeField] Transform _middlePosition;
    [SerializeField] float _radius;
    [Header("ANIMATOR & PARTICULES")]
    [SerializeField] Animator _animator;
    [SerializeField] string _UltimName;
    [SerializeField] UnityEvent _particulesUltim;


    public void Ultime(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                _inputUltime = true;

                if (_inputUltime == true && GameManager.instance.Score >= 50)
                {
                    _animator.SetTrigger(_UltimName);
                    StartCoroutine(UltimParticuleWait());
                    _inputUltime = false;
                    GameManager.instance.SuppScore();
                    
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
                    //_particulesUltim.Invoke();
                    el.attachedRigidbody.GetComponent<Health>().TakeDomage(10);
                }


            }
        }
    }
    IEnumerator UltimParticuleWait()
    {

        yield return new WaitForSeconds(0.6f);
        _particulesUltim.Invoke();
        TableauRecastCircle();

    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_middlePosition.position, _radius);
    }
}
