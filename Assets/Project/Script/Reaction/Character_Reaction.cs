using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Reaction : MonoBehaviour
{
    [SerializeField] Material _blinkMat;
    public void Knockback(GameObject target, GameObject sender)
    {
        StartCoroutine(Knockbacking(target, sender));        
    }

    public void Blinking(GameObject a)
    {
        SpriteRenderer currentSprite = a.GetComponent<SpriteRenderer>();
        StartCoroutine(Blink(currentSprite));
    }

    void Fx()
    {

    }

    IEnumerator Blink(SpriteRenderer currentSprite)
    {
        Material currentMat = currentSprite.material;

        for (int i = 0; i < 2; i++)
        {
            yield return new WaitForSeconds(0.1f);
            currentSprite.material = _blinkMat;
            yield return new WaitForSeconds(0.1f);
            currentSprite.material = currentMat;
        }

        
    }

    IEnumerator Knockbacking(GameObject target, GameObject sender)
    {
            Rigidbody2D currentRgbd = target.GetComponent<Rigidbody2D>();
            currentRgbd.bodyType = RigidbodyType2D.Dynamic;
            currentRgbd.AddForce(new Vector2((target.transform.position.x - sender.transform.position.x), 0).normalized * 300);
            yield return new WaitForSeconds(0.1f);
            currentRgbd.bodyType = RigidbodyType2D.Kinematic;
            currentRgbd.velocity = Vector2.zero;
    }   
}
