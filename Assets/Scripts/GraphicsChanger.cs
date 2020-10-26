using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Dimension
{
    dimension2D,
    dimension3D
}

public class GraphicsChanger : MonoBehaviour
{
    [SerializeField]
    private GraphicsAlternative graphics;
    [SerializeField]
    private Dimension actualDimension;

    public void ChangeGraphics()
    {
        if (actualDimension == Dimension.dimension3D)
        {
            DestroyImmediate(gameObject.GetComponent<MeshFilter>());
            DestroyImmediate(gameObject.GetComponent<MeshRenderer>());
            var c = gameObject.AddComponent<SpriteRenderer>();
            c.sprite = graphics.sprite;
            c.color = graphics.color;
            actualDimension = Dimension.dimension2D;
        }
        else
        {
            DestroyImmediate(gameObject.GetComponent<SpriteRenderer>());
            gameObject.AddComponent<MeshFilter>().mesh = graphics.mesh;
            var c = gameObject.AddComponent<MeshRenderer>();
            c.material = graphics.material;
            c.material.SetColor("_Color", graphics.color);
            actualDimension = Dimension.dimension3D;
        }
    }
}
