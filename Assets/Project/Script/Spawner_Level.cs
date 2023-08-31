using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_Level : MonoBehaviour
{
    [SerializeField] GameObject _enemyToSpawn;

    float _maxDistanceFromStart = 0;

    private void Update()
    {
        if (Random.Range(0,75) == 1)
        {
            if (_maxDistanceFromStart < Vector3.Distance(transform.position, PlayerMovement.Instance.transform.position))
            {
                Instantiate(_enemyToSpawn, FindSpawnPointAroundPlayer(), Quaternion.identity);
                _maxDistanceFromStart = Vector3.Distance(transform.position, PlayerMovement.Instance.transform.position);
            }
        }
        
    }

   

    Vector3 FindSpawnPointAroundPlayer()
    {
        float direction;

        if (Random.Range(0, 2) < 1)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }
        

        float xValue;
        float yValue;
        

        xValue = PlayerMovement.Instance.transform.position.x + ((6 + Random.Range(2,8)) * direction) ;// +- cam distance + random distance
        yValue = transform.position.y + Random.Range(-3,3); // random +- cam distance

        Debug.Log(new Vector2(xValue, yValue));

        return new Vector2(xValue, yValue);
    }
}
