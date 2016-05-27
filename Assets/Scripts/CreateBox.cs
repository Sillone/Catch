using UnityEngine;
using System.Collections;
using System;

public class CreateBox : MonoBehaviour
{
    public GameObject boxExample;   //перфаб коробки
    public GameObject boomExample;  //перфаб(спрайт) взрыва

    public float range; //радиус окружности. нужен для правильного появления коробок

    public float speedRotationBox;  //скорость вращения бочки в верхней-левой части экрана

    public int countAllBoxes;       //кол-во бочек
    GameObject[] targets;       //объекты коробки
    int[] boxState;     //состояние коробки (0=нету, 1= есть одна, 2=есть две)
    bool[] boxChecked;  //прошёл ли кубик проверку(удалить его или нет). нужно для оптимизации и вращения
    int myTimer;

    GameObject[] boomSpr;       //массив взрывов    /оптимизируй меня просто спрайтом(возможно?)
    public int[] timeDelBoom;

    void Start()
    {
        timeDelBoom = new int[countAllBoxes];
        targets = new GameObject[countAllBoxes];
        boomSpr = new GameObject[countAllBoxes];
        boxChecked = new bool[countAllBoxes];
        boxState = new int[countAllBoxes];
        for (int i = 0; i < countAllBoxes; i++)
        {
            timeDelBoom[i] = 0;
            boxState[i] = 0;
            boxChecked[i] = true;
        }

        range = 1.32f;
        myTimer = 0;
    }

    void FixedUpdate()
    {
        for (int i = 0; i < countAllBoxes; i++)
        {
            if (boxState[i] == 1)   //если коробка существует
            {
                if (boxChecked[i] == false) //и она не прошла проверку(она находится слева или внизу)
                {
                    if (targets[i].transform.position.x > 1.2f) //и она дошла до точки справа
                    {
                        if (UnityEngine.Random.Range(0, 2) == 0)    //удалить или нет?
                        {
                            boxState[i] = 0;
                            DeleteBox(i);       //удаляем
                            Debug.Log("i'm out!");
                        }
                        else
                        {
                            boxChecked[i] = true;   //хочу вращаться 
                        }
                    }
                }
                else
                {
                    targets[i].transform.Rotate(new Vector3(0, 0, speedRotationBox) * Time.deltaTime);  //йююююху
                    if (targets[i].transform.position.x < -1.2f)    //если она дошла до рабочей  части экрана(рядом с кошой), то стоит перестать это делать
                    {
                        boxChecked[i] = false;
                    }
                }
            }
        }
    }

    void Update()
    {
        myTimer++;
        if (myTimer >= 150)     //usualy we will create a boxes
        {                           //max count == countAllBoxes
            myTimer = 0;
            for (int i = 0; i < countAllBoxes; i++)
                if (boxState[i] == 0)
                {
                    AddBox(i);
                    break;
                }
        }

        for (int i = 0; i < countAllBoxes; i++)     //проверяем на взрыв
        {
            if (boxState[i] == 3)
            {
                if (timeDelBoom[i] == 0)
                {
                    DeleteBoom(i);
                }
                timeDelBoom[i]--;
            }
        }
        // check =  UnityEngine.Random.Range(0, 2);
    }

    void AddBox(int n)  
    {
        boxState[n] = 1;//для начального вращения
        Debug.Log("new box");
        targets[n] = (GameObject) Instantiate(boxExample, new Vector2(0, range), Quaternion.identity);//создаёт кубик
        targets[n].transform.parent = GameObject.Find("Boxes").transform ;  //привязывыаем его к платформе)
        targets[n].name = "myBox" + n.ToString();


    }

    void DeleteBox(int n)//для добавления взрыва после смерти кубика
    {
        boomSpr[n] = (GameObject)Instantiate(boomExample, targets[n].transform.position, targets[n].transform.rotation);
        boomSpr[n].transform.parent = GameObject.Find("Boxes").transform;
        Destroy(targets[n]);
        boxState[n] = 3;
        timeDelBoom[n] = 40;
    }

    void DeleteBoom(int n)
    {
        boxState[n] = 0;
        Destroy(boomSpr[n]);
    }
}
