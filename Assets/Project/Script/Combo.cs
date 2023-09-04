using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{
    [SerializeField] Character_Reaction _charReaction;

    int _comboIndex = 0;

    public void Comboing(GameObject target, GameObject sender)
    {

        

        switch (_comboIndex)
        {
            case 0:
                _charReaction.Hit(target, sender);
                break;
            case 1:
                _charReaction.Hit(target, sender);
                break;
            case 2:
                if (!target.gameObject.CompareTag("Boss"))
                {
                    _charReaction.HitKnockback(target, sender);     
                }
                else
                {
                    _charReaction.Hit(target, sender);
                }
                break;

        }
    }

    public void ResetComboIndex()
    {
        _comboIndex = 0; 
    }

    public void AddComboIndex()
    {
        _comboIndex++;
        if (_comboIndex > 2 )
        {
            _comboIndex = 2;
        }
    }
}
