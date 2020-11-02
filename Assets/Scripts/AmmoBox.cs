using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids;

public class AmmoBox : MonoBehaviour
{
    [SerializeField]
    private int capacity;
    private Asteroids.AmmoBox ammoBox;

    private void Start()
    {
        ammoBox = new Asteroids.AmmoBox(capacity);
    }
}
