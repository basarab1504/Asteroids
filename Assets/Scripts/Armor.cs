﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Armor : MonoBehaviour
{
    [SerializeField]
    private GameEvent Destoyed;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destoyed.Raise();
        Destroy(gameObject);
    }
}
