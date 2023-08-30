using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Character_Reaction _reactionManager;
    [SerializeField] SpriteRenderer _spriterender;

    [SerializeField] Combo _combo;

    List <Collider2D> _collidingObject = new List <Collider2D>();
    [SerializeField] UnityEvent _particulesHit;


    
    
    public void Attack()
    {
        if (CheckCollider().Count>0)
        {
            foreach (var collider in _collidingObject)
            {
                if (collider.transform.root.GetComponent<PlayerMovement>() != null)
                {
                    _particulesHit.Invoke();
                    //SendAttack
                    _combo.Comboing(collider.transform.gameObject,transform.gameObject);

                }
            }
        }
    }
    
    List<Collider2D> CheckCollider()
    {
        return _collidingObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _collidingObject.Add(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _collidingObject.Remove(collision);
    }
}
