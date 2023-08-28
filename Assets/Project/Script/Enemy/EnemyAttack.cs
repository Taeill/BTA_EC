using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Character_Reaction _reactionManager;
    [SerializeField] SpriteRenderer _spriterender;

    List <Collider2D> _collidingObject = new List <Collider2D>();

    
    
    public void Attack()
    {
        if (CheckCollider().Count>0)
        {
            foreach (var collider in _collidingObject)
            {
                if (collider.transform.root.GetComponent<PlayerMovement>() != null)
                {
                    //SendAttack
                    _reactionManager.Blinking(collider.transform.root.GetComponentsInChildren<SpriteRenderer>()[0].transform.gameObject);
                    _reactionManager.Knockback(collider.transform.root.gameObject, this.gameObject);
                    collider.transform.root.gameObject.GetComponent<Health>().TakeDomage();
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
