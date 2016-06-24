using UnityEngine;
using System.Collections;

public class laser : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("something doing");
        if (col.GetComponent<BoxCollider2D>().tag == "Wall")
        {
            Debug.Log("laser in box!");
            LaserHelper.nameOfLasered = col.gameObject.name;
            //col.gameObject
        }
    }

   /* void OnTriggerEnter2D(GameObject GO)
    {
        Debug.Log("something doing with GO");   
        if (GO.collider2D.GetComponent<BoxCollider2D>().tag == "Wall")
        {
            Debug.Log("laser in box!");
        }
    }*/
}
