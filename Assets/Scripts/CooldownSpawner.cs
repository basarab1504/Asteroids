using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CooldownSpawner : Spawner
{
    [SerializeField]
    private float cooldown;
    private float lastTickSpawned;

    public void Update()
    {
        if(Time.time > lastTickSpawned + cooldown)
        {
            lastTickSpawned = Time.time;
            Spawn();
        }
    }
}
