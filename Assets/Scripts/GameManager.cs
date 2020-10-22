using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int lifesAmount;
    private int lifesRemain;
    [SerializeField]
    private Ship playerShipPrefab;
    [SerializeField]
    private Vector2 shipSpawnPosition;

    private void Start()
    {
        lifesRemain = lifesAmount;
        SpawnShip();
    }

    public void OnShipExploded()
    {
        if (lifesRemain > 0)
        {
            SpawnShip();
            lifesRemain--;
        }
    }

    public Ship SpawnShip()
    {
        var ship = Instantiate(playerShipPrefab, shipSpawnPosition, Quaternion.identity);
        ship.ShipExploded.AddListener(OnShipExploded);
        return ship;
    }
}
