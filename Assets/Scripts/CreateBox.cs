using UnityEngine;
using System.Collections;
using System;

public class CreateBox : MonoBehaviour
{
    public GameObject boxExample;
    public float range;

    GameObject[] targets = new GameObject[5];
    int myTimer;
    int minNumOfBoxes;
    int activeBoxes;

    void Start()
    {
        range = 1.4f;
        // AddBox();
        activeBoxes = 0;
        myTimer = 0;
        minNumOfBoxes = 0;
    }

    void Update()
    {
        myTimer++;
        if (myTimer >= 150)     //usualy we will create a boxes
        {
            myTimer = 0;
            AddBox(minNumOfBoxes);

            minNumOfBoxes++;
            if (minNumOfBoxes >= 5)
                minNumOfBoxes -= minNumOfBoxes;
        }
       /* foreach (var item in collection)
        {

        }*/
        for (int i = 0; i < activeBoxes; i++)       //chek EACH EXISTED box for ending
        {
            if ((targets[i] != null) && (targets[i].transform.position.x > 1f))       //check to delete
            {
                Debug.Log("i'm out!");
                DeleteBox(i);
            }
        }
    }

    void AddBox(int n)
    {
        Debug.Log("new box");
        targets[n] = new GameObject();
        targets[n] = (GameObject) Instantiate(boxExample, new Vector2(0, range), Quaternion.identity);
        targets[n].transform.parent = GameObject.Find("Boxes").transform ;
        activeBoxes++;
    }

    void DeleteBox(int n)
    {
        Destroy(targets[n]);
        activeBoxes--;
      //  Destroy(gameObject);
    }

}
