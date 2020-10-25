using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    protected override void Update()
    {
        var hit = Physics2D.OverlapCircle(transform.position, visibilityRadius, aimMask);
        if (hit != null)
        {
            if ((hit.transform.position - transform.position).magnitude > keepDistance)
                mainGun.Shoot();

            float signedAngle = Vector3.SignedAngle(transform.up, hit.transform.position - transform.position, Vector3.forward);
            if (signedAngle >= visibilityAngle)
            {
                Rotate(rigidbody.rotation + rotationSpeed * Mathf.Sign(signedAngle));
            }

            var dir = hit.transform.position - transform.position;
            if (dir.magnitude > keepDistance)
            {
                Move(dir.normalized * speed);
            }
        }
    }
}
