using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameEvent Destoyed;

    private void OnDestroy()
    {
        Destoyed.Raise();
    }
}
