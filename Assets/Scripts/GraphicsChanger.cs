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
    private GraphicsSettings settings;

    private void Start()
    {
        if (NeedsToChangeGraphics())
            ChangeGraphics();
    }

    private bool NeedsToChangeGraphics()
    {
        if (settings.graphicsDimension == Dimension.dimension3D)
            return GetComponent<MeshRenderer>() == null;
        else
            return GetComponent<SpriteRenderer>() == null;
    }

    private void ChangeGraphics()
    {
        if (settings.graphicsDimension == Dimension.dimension3D)
        {
            DestroyImmediate(gameObject.GetComponent<SpriteRenderer>());
            gameObject.AddComponent<MeshFilter>().mesh = graphics.mesh;
            gameObject.AddComponent<MeshRenderer>().material = graphics.material;
        }
        else
        {
            DestroyImmediate(gameObject.GetComponent<MeshFilter>());
            DestroyImmediate(gameObject.GetComponent<MeshRenderer>());
            gameObject.AddComponent<SpriteRenderer>().sprite = graphics.sprite;
            gameObject.GetComponent<SpriteRenderer>().color = graphics.color;
        }
    }
}
