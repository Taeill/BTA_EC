using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Reaction : MonoBehaviour
{
    [SerializeField] Material _blinkMat;
    public void Knockback(GameObject a)
    {
        Rigidbody2D currentRgbd = a.GetComponent<Rigidbody2D>();
        currentRgbd.bodyType = RigidbodyType2D.Dynamic;
        currentRgbd.AddForce(new Vector2 (1000,0));
        //currentRgbd.bodyType = RigidbodyType2D.Kinematic;
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
}
