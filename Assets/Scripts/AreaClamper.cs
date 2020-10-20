using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaClamper : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    {
        transform.position = -transform.position;
    }
}
