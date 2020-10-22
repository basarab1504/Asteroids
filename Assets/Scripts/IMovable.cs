﻿using UnityEngine;

public interface IMovable
{
    void Move(Vector3 direction);
    void Rotate(float angle);
}
