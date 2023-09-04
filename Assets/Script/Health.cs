using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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
    bool IsBoss() => gameObject.CompareTag("Boss");
    public bool IsDead() => _currentHealth <= 0;
    
    private void Awake()
    {
        _currentHealth = _hpMax;

    }
    // Start is called before the first frame update

    private void Start()
    {
    }
    public void TakeDomage(int count)
    {
        // Guard
        if (count < 0) { Debug.LogError(""); return; }

        // Update Health
        if (IsEnemy() || IsPlayer() || IsBoss())
        {
            _currentHealth = Mathf.Max(0, _currentHealth-count);
            if(IsBoss() ) 
            {
                GameManager.instance.SuppLifeBoss(_currentHealth);
            }
        }
        // PLayer update slider
        if (IsPlayer())
        {
            GameManager.instance.SuppLife(_currentHealth);
        }


        // Death
        if (IsDead())
        {
            
            _animator.SetTrigger("Death");

            ;
            //Destroy(gameObject);
            //Debug.Log("DeathEnemy");
            if (IsEnemy())
            {
                GameManager.instance.AddScore(10);

            }
            if(IsBoss())
            {
                Debug.Log("BossMort");
                StartCoroutine(LoadSceneWin());
                PlayerMovement.Instance.transform.root.gameObject.GetComponentInChildren<Animator>().SetTrigger("Win");
               //StartCoroutine(DeathRoutine())
                //SceneManager.LoadScene("Win");
            }
        }
   IEnumerator LoadSceneWin() 
        {
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("Win");
            
        
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
