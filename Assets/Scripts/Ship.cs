using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids;

public class Ship : MonoBehaviour, IShip
{
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected float rotationSpeed;
    [SerializeField]
    protected List<Gun> guns;
    protected Rigidbody2D rigidbody;

    public float Speed => speed;
    public float RotationSpeed => rotationSpeed;
    public IEnumerable<IGun> Guns => guns;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            Move(new Coordinates3D(transform.up.x, transform.up.y, transform.up.z) * speed);
        if (Input.GetKey(KeyCode.LeftArrow))
            Rotate(rigidbody.rotation + rotationSpeed);
        if (Input.GetKey(KeyCode.RightArrow))
            Rotate(rigidbody.rotation - rotationSpeed);
        if (Input.GetKeyDown(KeyCode.Space))
            guns[0].Shoot(new Coordinates3D(transform.up.x, transform.up.y, transform.up.z));
        if (Input.GetKeyDown(KeyCode.RightControl))
            guns[1].Shoot(new Coordinates3D(transform.up.x, transform.up.y, transform.up.z));
    }

    public void Move(Coordinates3D direction)
    {
        rigidbody.AddForce(new Vector3(direction.X, direction.Y, direction.Z));
    }
    public void Rotate(float angle)
    {
        rigidbody.MoveRotation(angle);
    }
    public void Shoot(Coordinates3D direction)
    {
        /////////////////AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}