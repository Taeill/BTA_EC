using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_AnimEvent : MonoBehaviour
{
    [SerializeField] EnemyAttack _enemyAttack;
    [SerializeField] Combo _Combo;
    void AnimAttack()
    {
        Debug.Log("Attack");
        _enemyAttack.Attack();
    }
      
    void AnimComboAdd()
    {
        _Combo.AddComboIndex();
    }

    void AnimComboReset()
    {
        StartCoroutine(ComboReset());
    }

    IEnumerator ComboReset()
    {
        yield return new WaitForSeconds(1);
        _Combo.ResetComboIndex();
    }
}
