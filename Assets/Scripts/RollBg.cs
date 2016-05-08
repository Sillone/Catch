using UnityEngine;
using System.Collections;

public class RollBg : MonoBehaviour {

    public float speed;
    public Transform rollingThing;

    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        rollingThing.transform.Rotate(new Vector3(0, 0, speed) * Time.deltaTime);
    }
}
