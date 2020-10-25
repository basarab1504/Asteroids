using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected float rotationSpeed;
    [SerializeField]
    protected Gun mainGun;
    [SerializeField]
    protected Gun secondaryGun;
    protected Rigidbody2D rigidbody;

    public void Move(Vector3 direction)
    {
        rigidbody.AddForce(direction);
    }

    public void Rotate(float angle)
    {
        rigidbody.MoveRotation(angle);
    }

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            Move(transform.up * speed);
        if (Input.GetKey(KeyCode.LeftArrow))
            Rotate(rigidbody.rotation + rotationSpeed);
        if (Input.GetKey(KeyCode.RightArrow))
            Rotate(rigidbody.rotation - rotationSpeed);
        if (Input.GetKeyDown(KeyCode.Space))
            mainGun.Shoot();
        if (Input.GetKeyDown(KeyCode.RightControl))
            secondaryGun.Shoot();
    }
}