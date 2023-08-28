using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Character_Reaction _reactionManager;
    [SerializeField] SpriteRenderer _spriterender;

    List <GameObject> _collidingObject = new List <GameObject>();

    
    
    public void Attack()
    {
        if (CheckCollider().Count>0)
        {
            foreach (var collider in _collidingObject)
            {
                if (collider.transform.root.GetComponent<PlayerMovement>() != null)
                {
                    //SendAttack
                    Debug.Log("maisnnonmaisc'estunedingzomg");
                    _reactionManager.Blinking(_spriterender.transform.gameObject);
                    _reactionManager.Knockback(transform.root.gameObject);
                }
            }
        }
    }
    
    List<GameObject> CheckCollider()
    {
        return _collidingObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _collidingObject.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _collidingObject.Remove(collision.gameObject);
    }
}
