using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    [SerializeField] GameObject _target;
    [SerializeField] GameObject _enemyToSpawn;
    [SerializeField] Animator _animator;

    public List<GameObject> _spawnedObj = new List<GameObject>();


    enum _bossStates
    {
        TargettingState,
        IdleState
    }

    _bossStates _state = _bossStates.IdleState;


    private void Start()
    {
        StartCoroutine(BossStart());
    }

    IEnumerator BossStart()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(Routine());
    }

    IEnumerator Routine()
    {

        _state = _bossStates.TargettingState;
        _animator.SetBool("MusicAttack", true);

        StartCoroutine(Targetting());

        yield return new WaitForSeconds(Random.Range(4, 5));

        _state = _bossStates.IdleState;
        _animator.SetBool("MusicAttack", false);

        spawnEnemy();

        yield return new WaitForSeconds(Random.Range(7, 10));



        StartCoroutine(Routine());

    }

    IEnumerator Targetting()
    {
        GameObject spawned = Instantiate(_target, transform.position, transform.rotation);

        if (spawned.GetComponent<Boss_>() != null)
        {
            spawned.GetComponent<Boss_>().Owner = gameObject.GetComponent<BossBehavior>();
        }
        

        _spawnedObj.Add(spawned.gameObject);
        yield return new WaitForSeconds(2);

        if (_state == _bossStates.TargettingState)
        {
            StartCoroutine(Targetting());
        }

    }

    void spawnEnemy()
    {


        switch (Random.Range(1, 5))
        {
            case 2:
                GameObject _spawnedEnemy = Instantiate(_enemyToSpawn, transform.position, transform.rotation);
                if (_spawnedEnemy.GetComponent<Enemy_Behavior>() != null)
                {
                    _spawnedEnemy.GetComponent<Boss_>().Owner = gameObject.GetComponent<BossBehavior>();
                }
                _spawnedObj.Add(_spawnedEnemy.gameObject);
                
                break;
        }
    }
}
