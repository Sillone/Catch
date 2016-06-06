using UnityEngine;
using System.Collections;


public class CatLaser : Controll
{

    public GameObject exampleLaser;
    GameObject laser;
    public bool laserd = false;
    public int laserTime = 20;
    int liserTimeCurent;

    public int test = 0;

    protected override void Update()
    {
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || (Input.GetKeyDown(KeyCode.Space)))
        {
            ////can we fucking jump?
            distGround = Vector2.Distance(groundCheck.position, catGO.transform.position);
            if (distGround < groundRadius)
            {

                myAnimator.SetBool("isGround", true);
                grounded = true;
            }
            else
            {
                grounded = false;
                myAnimator.SetBool("isGround", false);
                for (int i = 0; i < 5; i++)
                {
                    if (GameObject.Find("myBox" + i))
                    {
                        distBox[i] = Vector2.Distance(GameObject.Find("myBox" + i).transform.position, catGO.transform.position);
                        if (distBox[i] < boxRadius && GameObject.Find("myBox" + i).transform.position.y < -0.9f)
                        {
                            grounded = true;
                            myAnimator.SetBool("isGround", true);
                            break;
                        }
                    }
                }
            }//now we know this

            if (grounded)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
            }
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.K))    ///laser
        {
            if (!laserd)
            {
                laserd = true;
                Vector2 temp = catGO.transform.position;
                temp.x = temp.x - 1.3f;
                laser = (GameObject)Instantiate(exampleLaser, temp, Quaternion.identity);
                laser.transform.parent = GameObject.Find("cat laser").transform;
                liserTimeCurent = laserTime;
                laser.name = "LASER";
                
            }
        }


    }
    

    void FixedUpdate()
    {
        if (laserd)
        {
            if (liserTimeCurent == 0)
            {
                DeleteLaser();
            }
            liserTimeCurent--;
        }
    }

    void DeleteLaser()
    {
        laserd = false;
        Destroy(laser);
        
    }
}
