using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Graphics", menuName = "ScriptableObjects/GraphicsSet", order = 1)]
public class GraphicsAlternative : ScriptableObject
{
    [SerializeField]
    public Sprite sprite;
    [SerializeField]
    public Color color;
    [SerializeField]
    public Mesh mesh;
    [SerializeField]
    public Material material;
}
