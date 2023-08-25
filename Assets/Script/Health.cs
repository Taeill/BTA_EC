using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public string m_damagingTag = "";
    [Header("Health")]
    [SerializeField] int _healthPoints = 3;
    [SerializeField] int _hpMax = 3;


    private void Awake()
    {
        _healthPoints = _hpMax;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
