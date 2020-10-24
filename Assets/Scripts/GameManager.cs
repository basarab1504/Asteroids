using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

[Serializable]
public class StringEvent : UnityEvent<string>
{}

public class GameManager : MonoBehaviour
{
    public StringEvent ScoreChanged;
    public UnityEvent GameStarted;
    public UnityEvent GameOver;
    [SerializeField]
    private int score;

    private void Start()
    {
        GameStarted.Invoke();
    }

    public void AddScore()
    {
        score++;
        ScoreChanged.Invoke(score.ToString());
        Debug.Log(score);
    }

    public void OnShipExploded()
    {
        GameOver.Invoke();
    }

    public void OnGameRestart()
    {
        GameStarted.Invoke();
    }
}
