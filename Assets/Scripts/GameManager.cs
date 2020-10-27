using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using UnityEngine.SceneManagement;

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
    [SerializeField]
    private GraphicsSettings settings;

    private void Start()
    {
        GameStart.Raise();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ChangeGraphics()
    {
        if (settings.graphicsDimension == Dimension.dimension2D)
            settings.graphicsDimension = Dimension.dimension3D;
        else
            settings.graphicsDimension = Dimension.dimension2D;
        GraphicsChanged.Raise();
    }

    public void AddScore()
    {
        score++;
        ScoreChanged.Invoke(score.ToString());
    }
}
