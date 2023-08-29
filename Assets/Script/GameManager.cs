using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int _score = 0;
    [SerializeField] TextMeshProUGUI _textPlayerLife;
    [SerializeField] TextMeshProUGUI _textScore;

    public static GameManager instance
    {

        get; private set;
    }
    public int Score { get => _score; }

    [SerializeField] int _lifePlayer = 3;


    private void Awake()
    {

        instance = this;
        _textPlayerLife.text = _lifePlayer.ToString();

    }
    internal void SuppLife(int count)
    {
        _lifePlayer -= count;
        _textPlayerLife.text = _lifePlayer.ToString();

    }
    internal void AddScore(int count)
    {
        _score += count;
        //transformer int en string 
        _textScore.text = _score.ToString();

    }

    public void SuppScore()
    {
        _score = 0;
        _textScore.text = _score.ToString();

    }
}