using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

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
