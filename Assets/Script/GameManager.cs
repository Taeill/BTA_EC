using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _textPlayerLife;
    [SerializeField] TextMeshProUGUI _textScore;
    [SerializeField] int _lifePlayer = 3;
    [Header("Ultim")]
    [SerializeField] Slider _SlyderUltimBar;
    [SerializeField] int _score = 0;
    
    public static GameManager instance
    {

        get; private set;
    }
    public int Score { get => _score; }


    private void Awake()
    {

        instance = this;
        if(_textPlayerLife!=null) _textPlayerLife.text = _lifePlayer.ToString();
        
    }
    private void Update()
    {
        if (_SlyderUltimBar != null) _SlyderUltimBar.value = _score;
    }

    internal void SuppLife(int count)
    {
        _lifePlayer -= count;
        if (_textPlayerLife != null) _textPlayerLife.text = _lifePlayer.ToString();

    }
    internal void AddScore(int count)
    {
        _score += count;
        //transformer int en string 
        _textScore.text = _score.ToString();
        _SlyderUltimBar.value = _score;

    }

    public void SuppScore()
    {
        _score = 0;
        _textScore.text = _score.ToString();

    }
}