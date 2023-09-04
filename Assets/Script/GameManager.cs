using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _textPlayerLife;
    [SerializeField] TextMeshProUGUI _textScore;
    [Header("Ultim")]
    [SerializeField] Slider _SlyderUltimBar;
    [SerializeField] int _score = 0;
    [Header("HP && SCORE")]
    [SerializeField] int _lifePlayer  ;
    [SerializeField] Slider _SlyderHealth;
    [Header ("HP BOSS")]
    [SerializeField] int _lifeBoss;
    Slider _SlyderHealthBoss;
    
    
    public static GameManager instance
    {

        get; private set;
    }
    public int Score { get => _score; }


    private void Awake()
    {

        instance = this;
        if(_textPlayerLife!=null) _textPlayerLife.text = _lifePlayer.ToString();

        if (_SlyderHealth != null) _SlyderHealth.value = _lifePlayer;


        
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(5);

        //Recup du slider -> transform en gameObject et "find" le gameObject dans la scene ->recuperation du slider
        _SlyderHealthBoss = GameObject.Find("HpBarBoss").GetComponent<Slider>();

        if (_SlyderHealthBoss != null) _SlyderHealthBoss.value = _lifeBoss;
    }
    private void Update()
    {
        if (_SlyderUltimBar != null) _SlyderUltimBar.value = _score;
        
        


    }

    internal void SuppLife(int newValue)
    {
        _lifePlayer = newValue;
        if (_textPlayerLife != null) _textPlayerLife.text = _lifePlayer.ToString();
        if (_SlyderHealth != null) _SlyderHealth.value = _lifePlayer;

    }
    public void SuppLifeBoss(int newValue)
    {
        _lifeBoss = newValue;
        if (_SlyderHealthBoss != null) _SlyderHealthBoss.value = _lifeBoss;
    }
    internal void AddScore(int count)
    {
        _score += count; 
        _textScore.text = _score.ToString();
        _SlyderUltimBar.value = _score;

    }

    public void SuppScore()
    {
        _score = 0;
        _textScore.text = _score.ToString();

    }
}