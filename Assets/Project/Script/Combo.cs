using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{
    [SerializeField] Character_Reaction _charReaction;

    int _comboIndex = 0;
    bool _combo = false;

    public void Comboing(GameObject target, GameObject sender)
    {
        switch (_comboIndex)
        {
            case 0:
                _charReaction.Hit(target, sender);
                break;
            case 1:
                _charReaction.Hit(target, sender);
                _combo = true;
                break;
            case 2:
                _charReaction.HitKnockback(target, sender);
                _combo = false;
                break;
        }
    }

    public void ResetComboIndex()
    {
        if (!_combo)
        {
            _comboIndex = 0;
        }
        
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
