using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

[Serializable]
public class StringEvent : UnityEvent<string>
{ }

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameEvent GraphicsChanged;
    [SerializeField]
    private GameEvent GameStart;
    [SerializeField]
    private StringEvent ScoreChanged;
    private int score;
    private Dimension graphicsState;

    private void Start()
    {
        graphicsState = Dimension.dimension2D;
        GameStart.Raise();
    }

    public void Restart()
    {
        GameStart.Raise();
    }

    public void ChangeGraphics()
    {
        GraphicsChanged.Raise();
    }

    public void AddScore()
    {
        score++;
        ScoreChanged.Invoke(score.ToString());
    }
}
