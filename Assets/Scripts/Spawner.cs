using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Asteroids;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    protected IFactory<IPositional> factory;
    [SerializeField]
    protected Transform areaSize;
    private Spawner<IPositional> spawner;
    
    private void Start()
    {
        Debug.Log("YOU BIRC");
        // spawner = new Spawner<IPositional>(factory);
    }

    public void Spawn()
    {
        spawner.Spawn();
    }

    // private Vector2 GetPosition()
    // {
    //     float x;
    //     float y;

    //     var areaSizeX = areaSize.localScale.x * 0.5f;
    //     var areaSizeY = areaSize.localScale.y * 0.5f;

    //     bool XoY = Random.Range(0f, 1f) > 0.5f ? true : false;

    //     if (XoY)
    //     {
    //         x = Random.Range(0f, 1f) > 0.5f ? -areaSizeX : areaSizeX;
    //         y = Random.Range(-areaSizeY, areaSizeY);
    //     }
    //     else
    //     {
    //         y = Random.Range(0f, 1f) > 0.5f ? -areaSizeY : areaSizeY;
    //         x = Random.Range(-areaSizeX, areaSizeX);
    //     }

    //     return new Vector2(x, y);
    // }
}
