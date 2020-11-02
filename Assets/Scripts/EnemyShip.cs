using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Asteroids;

public class EnemyShip : Ship
{
    [SerializeField]
    private float visibilityAngle;
    [SerializeField]
    private float visibilityRadius;
    [SerializeField]
    private float keepDistance;
    [SerializeField]
    private LayerMask aimMask;

    private void Update()
    {
        var hit = Physics2D.OverlapCircle(transform.position, visibilityRadius, aimMask);
        if (hit != null)
        {
            if ((hit.transform.position - transform.position).magnitude > keepDistance)
                guns[0].Shoot(new Coordinates3D(transform.up.x, transform.up.y, transform.up.z));

            float signedAngle = Vector3.SignedAngle(transform.up, hit.transform.position - transform.position, Vector3.forward);
            if (signedAngle >= visibilityAngle)
            {
                Rotate(rigidbody.rotation + rotationSpeed * Mathf.Sign(signedAngle));
            }

            var dir = hit.transform.position - transform.position;
            if (dir.magnitude > keepDistance)
            {
                var dirNorm = dir.normalized * speed;
                Move(new Coordinates3D(dirNorm.x, dirNorm.y, dirNorm.z));
            }
        }
    }
}
