using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private float cooldown;
    private float lastTickSpawned;
    [SerializeField]
    private Vector2 areaSize;
    [SerializeField]
    private Asteroid asteroidPrefab;

    public void Update()
    {
        if(Time.time > lastTickSpawned + cooldown)
        {
            lastTickSpawned = Time.time;
            Spawn();
        }
    }

    public void Spawn()
    {
        var a = Instantiate(asteroidPrefab, GetPosition(), Quaternion.identity);
        a.PushRandom();
    }

    private Vector2 GetPosition()
    {
        float x;
        float y;

        bool XoY = Random.Range(0f, 1f) > 0.5f ? true : false;

        if (XoY)
        {
            x = Random.Range(0f, 1f) > 0.5f ? -areaSize.x : areaSize.x;
            y = Random.Range(-areaSize.y, areaSize.y);
        }
        else
        {
            y = Random.Range(0f, 1f) > 0.5f ? -areaSize.y : areaSize.y;
            x = Random.Range(-areaSize.x, areaSize.x);
        }

        return new Vector2(x, y);
    }
}
