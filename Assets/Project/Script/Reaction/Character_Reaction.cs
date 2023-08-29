using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Reaction : MonoBehaviour
{
    [SerializeField] Material _blinkMat;
    [SerializeField] Material _basicCharacterMat;


    public void Hit(GameObject target, GameObject sender)
    {
        target.transform.root.GetComponentInChildren<Animator>().SetTrigger("Hit");
        target.transform.root.gameObject.GetComponent<Health>().TakeDomage();
        Blinking(target.transform.root.GetComponentsInChildren<SpriteRenderer>()[0].transform.gameObject);
    }
    public void HitKnockback(GameObject target, GameObject sender)
    {
        target.transform.root.GetComponentInChildren<Animator>().SetTrigger("Knockbacked");
        target.transform.root.gameObject.GetComponent<Health>().TakeDomage();
        StartCoroutine(Knockbacking(target, sender));
        Blinking(target.transform.root.GetComponentsInChildren<SpriteRenderer>()[0].transform.gameObject);
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
        for (int i = 0; i < 2; i++)
        {
            yield return new WaitForSecondsRealtime(0.1f);
            currentSprite.material = _blinkMat;
            yield return new WaitForSecondsRealtime(0.1f);
            currentSprite.material = _basicCharacterMat;
        }

        
    }

    IEnumerator Knockbacking(GameObject target, GameObject sender)
    {
            Rigidbody2D currentRgbd = target.transform.root.GetComponent<Rigidbody2D>();
            currentRgbd.bodyType = RigidbodyType2D.Dynamic;
            currentRgbd.AddForce(new Vector2((target.transform.position.x - sender.transform.position.x), 0).normalized * 300);
            yield return new WaitForSeconds(0.1f);
            currentRgbd.bodyType = RigidbodyType2D.Kinematic;
            currentRgbd.velocity = Vector2.zero;
    }   
}
