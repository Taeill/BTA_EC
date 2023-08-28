using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AnimEvent : MonoBehaviour
{
    [SerializeField] EnemyAttack _enemyAttack;
    void AnimAttack()
    {
        Debug.Log("Attack");
        _enemyAttack.Attack();
    }
}
