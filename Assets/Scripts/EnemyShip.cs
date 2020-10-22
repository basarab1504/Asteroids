using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour, IMovable, IDestroyable
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private InputControl control;
    [SerializeField]
    private Gun gun;
    [SerializeField]
    private float visibilityAngle;
    [SerializeField]
    private float visibilityRadius;
    [SerializeField]
    private float keepDistance;
    [SerializeField]
    private LayerMask aimMask;

    private Rigidbody2D rigidbody;


    public void Move(Vector3 direction)
    {
        rigidbody.AddForce(direction);
    }

    public void Rotate(float angle)
    {
        rigidbody.MoveRotation(angle);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();

        control.commands = new List<Command>();

        control.commands.Add(new Command(() =>
        {
            var hit = Physics2D.OverlapCircle(transform.position, visibilityRadius, aimMask);
            var dir = hit.transform.position - transform.position;
            Move(dir.normalized * speed);
        },
        () =>
        {
            var hit = Physics2D.OverlapCircle(transform.position, visibilityRadius, aimMask);
            if (hit != null)
                return (hit.transform.position - transform.position).magnitude > keepDistance;
            return hit != null;
        }));

        control.commands.Add(new Command(() =>
        {
            var hit = Physics2D.OverlapCircle(transform.position, visibilityRadius, aimMask);
            if (Vector3.SignedAngle(transform.up, hit.transform.position - transform.position, Vector3.forward) < 0)
                Rotate(rigidbody.rotation - rotationSpeed);
            else
                Rotate(rigidbody.rotation + rotationSpeed);
        },
        () =>
        {
            var hit = Physics2D.OverlapCircle(transform.position, visibilityRadius, aimMask);
            if (hit != null)
            {
                return Vector3.Angle(transform.up, hit.transform.position - transform.position) >= visibilityAngle;
            }
            return false;
        }));

        control.commands.Add(new Command(() =>
        {
            gun.Shoot();
        },
        () =>
        {
            var hit = Physics2D.OverlapCircle(transform.position, visibilityRadius, aimMask);
            if (hit != null)
                return (hit.transform.position - transform.position).magnitude > keepDistance;
            return hit != null;
        }));
    }

    private void Update()
    {
        control.HandleCommands();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy();
    }
}
