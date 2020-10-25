﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Armor : MonoBehaviour
{
    public UnityEvent TotalDestroy;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        TotalDestroy.Invoke();
    }
}
