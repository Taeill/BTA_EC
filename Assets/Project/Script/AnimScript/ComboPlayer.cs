using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboPlayer : MonoBehaviour
{
    [SerializeField] Combo _Combo;
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
        Debug.Log("resetplayerCombo");
        yield return new WaitForSeconds(0.4f);
        _Combo.ResetComboIndex();
    }
}
