using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Box : MonoBehaviour
{
    protected int boxState; //состояние коробки (0=нету, 1= есть одна, 2=есть две)
    protected enum _BoxStates { UnExisted, Up, Down, NeedToStop, NeedToRoll, WhatWillDo };

    protected bool spawned;
    protected Transform trans;

    public float SpeedRotating;

    public float wasRotaded;
    public GameObject globalboomExample;

    public CreateBox BoxController;

    protected void Awake()
    {
        var Boxes = GameObject.Find("Boxes");
        BoxController= Boxes.GetComponent<CreateBox>();        

        trans = transform;
        spawned = true;
        boxState = 1;
        var temp = GameObject.FindGameObjectWithTag("Respawn").transform;
        trans.position = temp.position;
        trans.rotation = temp.rotation;
        trans.parent = Boxes.transform;
        gameObject.name = "GamingBox";
        BoxController.BoxesInSwawn++;
        boxState = (int)_BoxStates.Up;
    }

    public void IsDouble(int role)
    {

    }


    protected void FixedUpdate()
    {
        if (boxState == (int)_BoxStates.WhatWillDo)
        {
            if (UnityEngine.Random.Range(0, 2) == 0)    //удалить или нет?
                DeleteBox();       //удаляем
            else
                boxState = (int)_BoxStates.Up;
        }

        if (boxState == (int)_BoxStates.Up)
        {
            var speed = SpeedRotating * Time.deltaTime;
            trans.Rotate(new Vector3(0, 0, 1), speed);
            wasRotaded += speed;

            if (wasRotaded > 360)
                wasRotaded -= 360;
        }

        if (boxState == (int)_BoxStates.NeedToStop)
        {
            if (wasRotaded < 360 + 90)  //90 потому что у нас платформа не правильная какая-то
            {
                trans.Rotate(new Vector3(0, 0, 1), SpeedRotating * Time.deltaTime);
                wasRotaded += SpeedRotating * Time.deltaTime;
            }
            else
            {
                trans.Rotate(new Vector3(0, 0, 1), -wasRotaded + 360 + 90);
                boxState = (int)_BoxStates.Down;
                // wasRotaded = 0;
            }
        }
    }

    public void DeleteBox()
    {
        var boxes = GameObject.Find("Boxes");

        BoxController.DeleteBox(gameObject);
        boxState = (int)_BoxStates.UnExisted;

        var boomSpr = (GameObject)Instantiate(globalboomExample, transform.position, transform.rotation);
        boomSpr.transform.parent = boxes.transform;
        Destroy(gameObject);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.GetComponent<CircleCollider2D>())

            if (col.GetComponent<CircleCollider2D>().tag == "Respawn")
            {
                if (spawned)
                {
                    spawned = !spawned;
                    BoxController.BoxesInSwawn--;
                }
            }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<BoxCollider2D>())
        {
            switch (col.GetComponent<BoxCollider2D>().tag)
            {
                case "Respawn":
                    {
                        if (!spawned)
                        {
                            spawned = !spawned;
                            BoxController.BoxesInSwawn++;
                        }
                        break;
                    }

                case "Player":
                    {
                        Debug.Log("box in cat?");
                        break;
                    }
                case "Finish":
                    {
                        if (boxState == (int)_BoxStates.Up)
                            boxState = (int)_BoxStates.NeedToStop;
                        break;
                    }
                case "Deleter":
                    {
                        if (boxState == (int)_BoxStates.Down)
                            boxState = (int)_BoxStates.WhatWillDo;
                        break;
                    }
                case "Bullet":
                    {
                        DeleteBox();
                        break;
                    }
                default:
                    break;
            }
        }

        if (col.GetComponent<CircleCollider2D>())
        {
            if (col.GetComponent<CircleCollider2D>().tag == "Player")
            {
                col.GetComponent<Controll>().KillCat();
            }
        }
    }
}