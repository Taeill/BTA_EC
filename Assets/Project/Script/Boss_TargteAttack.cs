using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_ : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rgbd2D;
    [SerializeField] float _speed = 1;
    float _birthtime;
    float _lifeSpan;
    float _maxTime = 20;
    float _percentTime;
    private void Start()
    {
        _birthtime = Time.realtimeSinceStartup;
        _lifeSpan = _birthtime + Random.Range(10, _maxTime);
        StartCoroutine(TargetRoaming());
    }

    void Shoot()
    {
        Debug.Log("attacking");
        _rgbd2D.velocity = Vector2.zero;
        if (Vector3.Distance(transform.position, PlayerMovement.Instance.transform.position) < 1)
        {
            PlayerMovement.Instance.transform.root.GetComponent<Health>().TakeDomage(1);
        }
        
    }

    private void Update()
    {
        //StartCoroutine(TargetRoaming());
        _percentTime = 100 * ((Time.realtimeSinceStartup - _birthtime) / _lifeSpan);
    }

    IEnumerator TargetRoaming()
    {
        if (Time.realtimeSinceStartup - _birthtime < _lifeSpan)
        {
            GoTo();
            yield return new WaitForSeconds(Random.Range(0.1f,0.5f));
            StartCoroutine(TargetRoaming());

        }
        else
        {
            Shoot();
        }
        
    }

    void GoTo()
    {
        Vector2 currentPos = transform.position;
        _rgbd2D.velocity = ((FindLocation() - currentPos).normalized) * (_speed / (1 + _percentTime/100));
    }

    Vector2 FindLocation()
    {
        
        Vector2 startPos = PlayerMovement.Instance.transform.position;
        Vector2 result;
        Debug.Log(_percentTime);
        result = startPos + (Random.insideUnitCircle / 2 * (100 - _percentTime) / 5);

        return result;
    }


}
