using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaClamper : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    {
        float x = transform.position.x;
        float y = transform.position.y;

        Vector3 pos;

        if (Mathf.Abs(x) >= Mathf.Abs(y))
            pos = new Vector3(-x, y);
        else
            pos = new Vector3(x, -y);

        transform.position = pos;
    }
}
