using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ship : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationSpeed;
    public UnityEvent ShipExploded;

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
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        ShipExploded.Invoke();
    }
}
