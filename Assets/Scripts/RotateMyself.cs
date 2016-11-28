using UnityEngine;
using System.Collections;

public class RotateMyself : MonoBehaviour {
    public float Speed;

    private Vector3 v;
    private Transform trans;

    void Start()
    {
        trans = transform;
        v = new Vector3(0, 0, 1);
    }
    void FixedUpdate()
    {
        trans.Rotate(v, Speed);
    }
}
