using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class CreateBox : MonoBehaviour
{
    public GameObject globalBoxExample;   //перфаб коробки
    public GameObject globalboomExample;  //перфаб(спрайт) взрыва

    public float globalRange; //радиус окружности. нужен для правильного появления коробок

    public float startSpeedRotationBox;  //скорость вращения бочки в верхней-левой части экрана

    public float speedRotationBox;

    public int maxCountAllBoxes = 5;       //кол-во бочек
    public int curentCout = 0;

    int myTimer;
    int maxTimer;

    int indexEmpty;
   
    public List<Box> boxes = new List<Box>();



    void Start()
    {
        maxTimer = 150;
        maxCountAllBoxes = 5;
        curentCout = 0;
        globalRange = 1.33f;
    }


    void Update()
    {
        myTimer++;

        if (myTimer >= maxTimer)     //usualy we will create a boxes
        {                           //max count == countAllBoxes
            myTimer = 0;
            maxTimer = UnityEngine.Random.Range(145, 155);

            //  curentCout = boxes.Count;
            indexEmpty = boxes.FindIndex(FindEmpty);

            if (indexEmpty != -1)
            {
                boxes.RemoveAt(indexEmpty);
                boxes.Insert(indexEmpty, new Box());
                boxes[indexEmpty].AddBox(globalRange, indexEmpty, globalBoxExample);
                boxes[indexEmpty].boxState = 1;
                Debug.Log(" changed");
            }
            else if (curentCout < maxCountAllBoxes)
            {

                boxes.Add(new Box());
                boxes[curentCout].boxState = 1;

                boxes[curentCout].AddBox(globalRange, curentCout, globalBoxExample);

                Debug.Log(boxes[curentCout].boxState.ToString() + " pizdec");
                curentCout++;
            }

        }
    }


    void FixedUpdate()
    {
        int lenArra = boxes.Count;
        foreach (Box i in boxes) //проверяем на взрыв
        {
            if (i.boxState == 1)   //если коробка существует
            {
                if (i.boxChecked == false) //и она не прошла проверку(она находится слева или внизу)
                {
                    if (i.boxGO.transform.position.x > 1.2f) //и она дошла до точки справа
                    {
                        if (UnityEngine.Random.Range(0, 2) == 0)    //удалить или нет?
                        {
                            i.boxState = 0;
                            i.DeleteBox(globalboomExample);       //удаляем
                          //  boxes.Remove(i);
                            //boxes.Sort(new Box.SortByState());

                        }
                        else
                        {
                            i.boxChecked = true;   //хочу вращаться 
                        }
                    }
                }
                else
                {
                    if (i.started)
                        i.boxGO.transform.Rotate(new Vector3(0, 0, startSpeedRotationBox) * Time.deltaTime);  //йююююху
                    else
                        i.boxGO.transform.Rotate(new Vector3(0, 0, speedRotationBox) * Time.deltaTime);  //йююююху

                    if (i.boxGO.transform.position.x < -1.2f)    //если она дошла до рабочей  части экрана(рядом с кошой), то стоит перестать это делать
                    {
                        i.boxChecked = false;
                        if (i.started)
                            i.started = false;
                    }
                }
            }
            else
            {
              /*  if (i.Booming())
                {
                    boxes.Remove(i);
                    boxes.Sort(new Box.SortByState());
                    Debug.Log(boxes.Count.ToString() + " after delete");
                }*/
                i.Booming();
            }
        }
    }

    private static bool FindEmpty(Box bk)
    {
        if (bk.boxState == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }



}
