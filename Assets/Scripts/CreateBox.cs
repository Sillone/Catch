using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class CreateBox : MonoBehaviour
{    
    public int BoxesInSwawn;

    public int MaxCountAllBoxes;

    private float maxTimer;
    public float IntervalCreation;
    public float Delta;

    public GameObject globalBoxExample;

    public LinkedList<GameObject> ExistedBoxes;
    void Awake ()
    {
        BoxesInSwawn = 0;
    }

    void Start()
    {
        maxTimer = Time.time + IntervalCreation;
        ExistedBoxes = new LinkedList<GameObject>(); 
    //    var temp = GameObject.Find("GamingBox").GetComponent<Box>().
       // Time.timeScale = 0.5f;
    }


    void FixedUpdate()
    {
        if (Time.time >= maxTimer)   
        {
            if (ExistedBoxes.Count < MaxCountAllBoxes)
            {
                if (BoxesInSwawn == 0)
                {
                    var temp = (GameObject)Instantiate(globalBoxExample);
                    AddBox(temp);

                    maxTimer = Time.time + IntervalCreation + UnityEngine.Random.Range(-Delta, Delta);
                }
                else
                    maxTimer +=  Delta;                
            }

        }
    }

    public void AddBox(GameObject _box)
    {
        ExistedBoxes.AddLast(_box);
    }

    public void DeleteBox(GameObject _box)
    {
        ExistedBoxes.Remove(_box);
    }
}
