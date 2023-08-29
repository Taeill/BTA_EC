using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{
    [SerializeField] Character_Reaction _charReaction;

    int _comboCount = 1;
    public void Comboing(GameObject target, GameObject sender)
    {
        switch (_comboCount)
        {
            case 1:
                _charReaction.Hit(target, sender);
                _comboCount++;
                break;
            case 2:
                _charReaction.Hit(target, sender);
                _comboCount++;
                break;
            case 3:
                _charReaction.HitKnockback(target, sender);
                break;
        }
    }
}
