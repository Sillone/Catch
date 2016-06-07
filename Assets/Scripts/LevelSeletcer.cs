using UnityEngine;
using System.Collections;

public class LevelSeletcer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Q))
        {
            Application.LoadLevel("one");
        }

        if (Input.GetKey(KeyCode.W))
        {
            Application.LoadLevel("two");
        }

        if (Input.GetKey(KeyCode.E))
        {
            Application.LoadLevel("three");
        }
    }
}
