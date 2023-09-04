using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimEvent : MonoBehaviour
{
    [SerializeField] ParticleSystem _pushingFX;
    [SerializeField] float _radius;
    [SerializeField] LayerMask _middleMask;
    [SerializeField] Character_Reaction _charReaction;
    void PushAway()
    {
        _pushingFX.Play();
        Debug.Log("pushing");

        Collider2D[] allContact = Physics2D.OverlapCircleAll(transform.position, _radius, _middleMask);

        if (allContact.Length > 0)
        {
            foreach (Collider2D el in allContact)
            {
                Health h = el.attachedRigidbody.GetComponent<Health>();

                if (h != null)
                {
                    Rigidbody2D currentRgbd = el.attachedRigidbody;
                    _charReaction.Knock(el.gameObject, this.gameObject);
                }
            }
        }
    }
}
