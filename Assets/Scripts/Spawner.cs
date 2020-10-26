using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Spawner : MonoBehaviour
{
    [SerializeField]
    protected GameObject prefabToSpawn;
    [SerializeField]
    protected Transform areaSize;
    
    public void Spawn()
    {
        var obj = Instantiate(prefabToSpawn, GetPosition(), Quaternion.identity);
    }

    private Vector2 GetPosition()
    {
        float x;
        float y;

        var areaSizeX = areaSize.localScale.x * 0.5f;
        var areaSizeY = areaSize.localScale.y * 0.5f;

        bool XoY = Random.Range(0f, 1f) > 0.5f ? true : false;

        if (XoY)
        {
            x = Random.Range(0f, 1f) > 0.5f ? -areaSizeX : areaSizeX;
            y = Random.Range(-areaSizeY, areaSizeY);
        }
        else
        {
            y = Random.Range(0f, 1f) > 0.5f ? -areaSizeY : areaSizeY;
            x = Random.Range(-areaSizeX, areaSizeX);
        }

        return new Vector2(x, y);
    }
}
