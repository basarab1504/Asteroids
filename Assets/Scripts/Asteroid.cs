using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Vector3 direction;
    [SerializeField]
    private float speed = 10;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        // direction = (Vector3.zero - transform.position).normalized;
    }

    public void Update()
    {
        rigidbody.MovePosition(transform.position + direction * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    public void Push(Vector2 direction)
    {
        this.direction = direction;
    }

    public void PushRandom()
    {
        var x = Random.Range(0f, 1f) > 0.5f ? -1f : 1f;
        var y = Random.Range(0f, 1f) > 0.5f ? -1f : 1f;
        direction = new Vector2(x, y);
    }
}
