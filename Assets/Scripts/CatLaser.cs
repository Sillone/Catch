using UnityEngine;
using System.Collections;

public class CatLaser : MonoBehaviour
{
    public GameObject exampleLaser;
    GameObject laser;
    public bool laserd;
    public int laserTime;
    int liserTimeCurent;

    void Start()
    {
        laserd = false;
        laserTime = 40;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))    ///laser
        {
            if (!laserd)
            {
                laserd = true;
                Vector3 temp = gameObject.transform.position;
                temp.x = temp.x - 1.22f;
                temp.y += 0.08f; 
                temp.z -= 2;
                laser = (GameObject)Instantiate(exampleLaser, temp, Quaternion.identity);
                laser.transform.parent = gameObject.transform;
                liserTimeCurent = laserTime;
                laser.name = "LASER";
            }
        }
    }
    

    void FixedUpdate()
    {
        if (laserd)
        {
            liserTimeCurent--;
            if (liserTimeCurent == 0)            
                DeleteLaser();            

        }
    }

    void DeleteLaser()
    {
        laserd = false;
        Destroy(laser);        
    }
}
