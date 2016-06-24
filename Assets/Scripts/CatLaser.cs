using UnityEngine;
using System.Collections;


public class CatLaser : Controll
{

    public GameObject exampleLaser;
    GameObject laser;
    public bool laserd = false;
    public int laserTime = 20;
    int liserTimeCurent;

    protected override void Update()
    {
        distGround = Vector2.Distance(groundCheck.position, catGO.transform.position);

        ////can we fucking jump?            
        if (distGround < groundRadius)
        {
            myAnimator.SetBool(catStateName, true);
            grounded = true;
            ClickJump();
        }
        else
        {
            Debug.Log("set grounded?");
            grounded = false;
            myAnimator.SetBool(catStateName, false);
            for (int i = 0; i < 5; i++)
            {
                if (GameObject.Find("myBox" + i))
                {
                    distBox[i] = Vector2.Distance(GameObject.Find("myBox" + i).transform.position, catGO.transform.position);
                    if (distBox[i] < boxRadius && GameObject.Find("myBox" + i).transform.position.y < -0.9f)
                    {
                        grounded = true;
                        myAnimator.SetBool(catStateName, true);
                        ClickJump();                       
                        break;
                    }
                }
            }
        }//now we know this


        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        

        if (Input.GetKeyDown(KeyCode.K))    ///laser
        {
            if (!laserd)
            {
                laserd = true;
                Vector3 temp = catGO.transform.position;
                temp.x = temp.x - 1.21f;
                temp.z -= 2;
                laser = (GameObject)Instantiate(exampleLaser, temp, Quaternion.identity);
                laser.transform.parent = GameObject.Find(catName).transform;
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
            {
                DeleteLaser();
            }

           /* if (liserTimeCurent > 15)
                laser.transform.position -= new Vector3(0, 0.01f, 0);
            else
                laser.transform.position += new Vector3(0, 0.01f, 0);*/
        }
    }

    void DeleteLaser()
    {
        laserd = false;
        Destroy(laser);        
    }
}
