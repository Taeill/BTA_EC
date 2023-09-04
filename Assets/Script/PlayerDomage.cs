using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerDomage : MonoBehaviour
{
    [SerializeField] bool _inputPunch = false;
    [Header("Animation && Particules")]
    [SerializeField] Animator _animator;
    [SerializeField] UnityEvent _particulesHit;
    [SerializeField] int _countPunch = 0;
    [SerializeField] Character_Reaction _reactionManager;
    List<Collider2D> _collidingObject = new List<Collider2D>();

    [SerializeField] Combo _combo;

    [SerializeField] AnimationClip[] _animAttack;

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
                //Increment Combo Index When Attacking While Already Attacking
                foreach (var item in _animAttack)
                {
                    if (_animator.GetCurrentAnimatorClipInfo(0)[0].clip == item)
                    {
                        _combo.AddComboIndex();
                    }
                }

                break;
            case InputActionPhase.Canceled:
                _inputPunch = false;
                break;
            default:
                break;


        }
        if (_inputPunch == true)
        {
            _animator.SetTrigger("Attack");
            _animator.SetInteger("NumberAttack", _countPunch);

            if (_countPunch ==2)
            {
                _countPunch = -1;
            }
            _countPunch++;
            _inputPunch = false;
        }

    }


    List<Collider2D> CheckCollider()
    {
        return _collidingObject;
    }


    //Check la liste de rentree
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _collidingObject.Add(collision);
    }
    //Check la list de sortie
    private void OnTriggerExit2D(Collider2D collision)
    {
        _collidingObject.Remove(collision);
    }

    public void AttackPlayer()
    {
        if (CheckCollider().Count > 0)
        {
            foreach (var collider in _collidingObject.ToArray())
            {
                var h = collider.attachedRigidbody.GetComponent<Health>();
                if (h != null)
                {
                    Debug.Log("Touché!");
                    _particulesHit.Invoke();
                    _combo.Comboing(collider.transform.gameObject, transform.gameObject);
                }
            }
        }
    }

}
