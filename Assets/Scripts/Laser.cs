using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.DrawRay(transform.position, transform.up * 5, Color.red, 3);
            List<RaycastHit2D> hits = new List<RaycastHit2D>();
            int results = Physics2D.Raycast(transform.position, transform.up, new ContactFilter2D(), hits, 5);
            foreach (var a in hits)
                Destroy(a.collider.gameObject);
        }
    }
}
