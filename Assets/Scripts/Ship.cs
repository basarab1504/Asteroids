using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationSpeed;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            rigidbody.MovePosition(transform.position + transform.up * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftArrow))
            rigidbody.MoveRotation(rigidbody.rotation + rotationSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.RightArrow))
            rigidbody.MoveRotation(rigidbody.rotation - rotationSpeed * Time.deltaTime);
        // if (transform.position.x > maxBoundX)
        //     transform.position = new Vector3(minBoundX, transform.position.y, 0);
        // else if (transform.position.x < minBoundX)
        //     transform.position = new Vector3(maxBoundX, transform.position.y, 0);
        // else if (transform.position.y > maxBoundY)
        //     transform.position = new Vector3(transform.position.x, minBoundY, 0);
        // else if (transform.position.y < minBoundY)
        //     transform.position = new Vector3(transform.position.x, maxBoundY, 0);
    }
}
