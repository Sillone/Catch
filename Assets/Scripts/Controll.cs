using UnityEngine;
using System.Collections;

public class Controll : MonoBehaviour {
    Rigidbody2D rig;
    public float force= 0f;
    float posX, posY;
    public int state;
    
    // Use this for initialization
    void Start () {
        rig = GetComponent<Rigidbody2D>();
        posX = rig.position.x;
        posY = rig.position.y;
        state = 0;
    }
	
	// Update is called once per frame
	void Update () {

        if (state == 0)       //можно прыгать, мы не в воздухе
        {
            Debug.Log("can jump");
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                rig.AddForce(new Vector3(0, force, 0));
                state = 1;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rig.AddForce(new Vector3(0, force, 0));
                state = 1;
            }
        }
        else
        {
            Debug.Log("can't jump");
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<BoxCollider2D>().tag == "Wall") {
            rig.position = new Vector2(posX,0);
        }
    }
}

