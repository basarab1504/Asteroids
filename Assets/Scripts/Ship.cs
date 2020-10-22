using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ship : MonoBehaviour, IMovable, IDestroyable
{
    public UnityEvent ShipExploded;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private InputControl control;
    [SerializeField]
    private Gun mainGun;
    [SerializeField]
    private Gun secondaryGun;
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
        control.commands.Add(new Command(() => Move(transform.up * speed), () => Input.GetKey(KeyCode.UpArrow)));
        control.commands.Add(new Command(() => Rotate(rigidbody.rotation + rotationSpeed), () => Input.GetKey(KeyCode.LeftArrow)));
        control.commands.Add(new Command(() => Rotate(rigidbody.rotation - rotationSpeed), () => Input.GetKey(KeyCode.RightArrow)));
        control.commands.Add(new Command(() => mainGun.Shoot(), () => Input.GetKeyDown(KeyCode.Space)));
        control.commands.Add(new Command(() => secondaryGun.Shoot(), () => Input.GetKeyDown(KeyCode.RightControl)));
    }

    private void Update()
    {
        control.HandleCommands();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy();
        ShipExploded.Invoke();
    }
}