using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{

    [SerializeField] GameObject _startPos;
    [SerializeField] GameObject[] _enableList;
    [SerializeField] GameObject _fadeObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.root.CompareTag("Player"))
        {
            
            StartCoroutine(StartBossFight());
        }

    }

    IEnumerator StartBossFight()
    {
        _fadeObject.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(3);

        //PlayerMovement.Instance.transform.root.position = _startPos.transform.position;
        _fadeObject.GetComponent<Animation>()["AnimFadeToBlack"].speed = -1;
        _fadeObject.GetComponent<Animation>().Play();

        yield return new WaitForSeconds(1);

        //foreach (var item in _enableList)
        //{
        //    item.gameObject.SetActive(true);
        //}
    }
}
