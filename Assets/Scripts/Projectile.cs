using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Projectile 
{
    public GameObject prefab;
    public float mass;
    public float speed;
    public Vector3 localScale;
    public Vector3 localPosition = Vector3.zero;
    public int Score = 0;
}
