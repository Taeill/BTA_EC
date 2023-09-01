using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_ : MonoBehaviour
{
    [SerializeField] Material _blinkMat;
    [SerializeField] Material _basicMat;

    [SerializeField] SpriteRenderer _sprite;

    [SerializeField] Rigidbody2D _rgbd2D;
    [SerializeField] float _speed = 1;
    float _birthtime;
    float _lifeSpan;
    float _maxTime = 5;
    float _percentTime;
    private void Start()
    {
        _birthtime = Time.realtimeSinceStartup;
        _lifeSpan =  Random.Range(2,10);
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
        if (_percentTime >= 90)
        {
            StartCoroutine(Blink(_sprite));
        }
        if (_percentTime < 100)
        {
            GoTo();
            yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));
            StartCoroutine(TargetRoaming());
        }
        else
        {
            StopCoroutine(Blink(_sprite));
            Shoot();
            Destroy(this.transform.root.gameObject);
        }

    }

    void GoTo()
    {
        Vector2 currentPos = transform.position;
        _rgbd2D.velocity = ((FindLocation() - currentPos).normalized) * (_speed / (1 + _percentTime / 100));
    }

    Vector2 FindLocation()
    {

        Vector2 startPos = PlayerMovement.Instance.transform.position;
        Vector2 result;
        Debug.Log(_percentTime);
        result = startPos + (Random.insideUnitCircle / 2 * (100 - _percentTime) / 5);

        return result;
    }

    IEnumerator Blink(SpriteRenderer currentSprite)
    {
        yield return new WaitForSecondsRealtime(0.05f);
        currentSprite.material = _blinkMat;
        yield return new WaitForSecondsRealtime(0.05f);
        currentSprite.material = _basicMat;
        StartCoroutine(Blink(_sprite));
    }


}
