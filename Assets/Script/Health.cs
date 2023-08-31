using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    
    [Header("Health")]
    [SerializeField] int _currentHealth = 3;
    [SerializeField] int _hpMax = 3;
    [Header("ANIMATION && PARTICULES")]
    [SerializeField] Animator _animator;
    //[SerializeField] UnityEvent _onDeath;

    bool IsEnemy() => gameObject.CompareTag("Enemi");
    bool IsPlayer() => gameObject.CompareTag("Player");
    public bool IsDead() => _currentHealth <= 0;

    private void Awake()
    {
        _currentHealth = _hpMax;

    }
    // Start is called before the first frame update

    
    public void TakeDomage(int count)
    {
        // Guard
        if (count < 0) { Debug.LogError(""); return; }

        // Update Health
        if (IsEnemy() || IsPlayer())
        {
            _currentHealth = Mathf.Max(0, _currentHealth-count);
        }
        // PLayer update slider
        if (IsPlayer())
        {
            GameManager.instance.SuppLife(_currentHealth);
        }

        // Death
        if (IsDead())
        {
            Debug.Log("dfdf");
            _animator.SetTrigger("Death");

            //StartCoroutine(DeathRoutine());
            //Destroy(gameObject);
            //Debug.Log("DeathEnemy");
            if (IsEnemy())
            {
                GameManager.instance.AddScore(10);
            }
        }
    }

    //IEnumerator DeathRoutine()
    //{
    //    if(IsPlayer())
    //    {
    //    _animator.SetTrigger("Death");
    //    yield return new WaitForSeconds(1.5f);
    //    _onDeath.Invoke();
    //    yield return new WaitForSeconds(1.5f);
    //    Destroy(gameObject);

    //    }
    //    if (IsEnemy())
    //    {
    //        _animator.SetTrigger("Death");
    //        yield return new WaitForSeconds(2f);
    //        _onDeath.Invoke();
    //        //    yield return new WaitForSeconds(10f);
    //        //    Destroy(gameObject);
    //    }
    //}
}
