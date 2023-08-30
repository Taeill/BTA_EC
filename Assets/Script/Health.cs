using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    public string m_damagingTag = "";
    [Header("Health")]
    [SerializeField] int _currentHealth = 3;
    [SerializeField] int _hpMax = 3;


    private void Awake()
    {
        _currentHealth = _hpMax;

    }
    // Start is called before the first frame update


    public bool IsDead()
    {
        if (_currentHealth <= 0) return true;
        else return false;
    }
    public void TakeDomage(int count)

    {
        if (gameObject.CompareTag("Player"))
        {

            if (_currentHealth > 0)
            {
                _currentHealth--;
                GameManager.instance.SuppLife(1);

            }
        }
        else if (IsDead())
        {
            Debug.Log("Destroy");
        }
        if (gameObject.CompareTag("Enemi"))
        {
            if (_currentHealth > 0)
            {
                _currentHealth-=count;
                
            }
            if (IsDead())
            {
                Destroy(gameObject);
                GameManager.instance.AddScore(10);
            }
        }
    }

}
