using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Object Info", menuName = "Map Generator", order = 0 )]
public class ObjectInfo : ScriptableObject
{
    public Color color;
    public GameObject prefab;
    public Vector3 offset;
}
