using UnityEngine;
using System.Collections;
using System;

public class AroundEarth : MonoBehaviour
{

    public Transform Center;

    private Transform trans;

    public float SpeedRptation;
    public float SpeedChangeHeigh;

    private float angle;

    public float Heigh;

    private bool IsUp;

    void Start()
    {
        IsUp = true;
        trans = transform;
    }

    void FixedUpdate()
    {
        ChangeAngle();
        SetTransform();        

        ChangeHeigh();
    }

    public void SetTransform()
    {
        trans.position = new Vector3((float)Math.Sin(angle), (float)Math.Cos(angle)) * Heigh + Center.position;

        var temp = angle / 2;
        trans.rotation = new Quaternion((float)Math.Sin(temp), (float)Math.Cos(temp), 0, 0);
    }

    private void ChangeAngle()
    {
        angle -= SpeedRptation;
        if (angle < -360)
            angle += 360;
    }

    private void ChangeHeigh()
    {
        if (IsUp)
        {
            Heigh += SpeedChangeHeigh;
            if (Heigh > 2.6f)
                IsUp = false;
        }
        else
        {
            Heigh -= SpeedChangeHeigh;
            if (Heigh < 1.8f)            
                IsUp = true;            
        }
    }
}