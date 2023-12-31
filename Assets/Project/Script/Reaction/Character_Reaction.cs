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
        target.transform.root.gameObject.GetComponent<Health>().TakeDomage(1);
        if (target.transform.root. GetComponent<Health>() != null)
        {
            Blinking(target.transform.root.GetComponentsInChildren<SpriteRenderer>()[0].transform.gameObject);
        }
        
    }

    public void HitKnockback(GameObject target, GameObject sender)
    {
        target.transform.root.GetComponentInChildren<Animator>().SetTrigger("Knockbacked");
        target.transform.root.gameObject.GetComponent<Health>().TakeDomage(1);
        if (target.transform.root.GetComponent<Health>() != null)
        {
            StartCoroutine(Knockbacking(target, sender));
            Blinking(target.transform.root.GetComponentsInChildren<SpriteRenderer>()[0].transform.gameObject);
        }
        
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
            yield return new WaitForSecondsRealtime(0.05f);
            currentSprite.material = _blinkMat;
            yield return new WaitForSecondsRealtime(0.05f);
            currentSprite.material = _basicCharacterMat;
        }


    }

    IEnumerator Knockbacking(GameObject target, GameObject sender)
    {
        if (target.transform.root.GetComponentInChildren<Enemy_Movement>()!= null) target.transform.root.GetComponentInChildren<Enemy_Movement>().Stun = true;
        Rigidbody2D currentRgbd = target.transform.root.GetComponent<Rigidbody2D>();
        currentRgbd.bodyType = RigidbodyType2D.Dynamic;
        currentRgbd.AddForce(new Vector2((target.transform.position.x - sender.transform.position.x), 0).normalized * 300);
        yield return new WaitForSeconds(0.1f);
        currentRgbd.bodyType = RigidbodyType2D.Kinematic;
        currentRgbd.velocity = Vector2.zero;
        yield return new WaitForSeconds(1f);
        if (target.transform.root.GetComponentInChildren<Enemy_Movement>() != null) target.transform.root.GetComponentInChildren<Enemy_Movement>().Stun = false;
    }

    public void Knock(GameObject target, GameObject sender)
    {
        StartCoroutine(Knockbacking(target, sender));
    }
}
