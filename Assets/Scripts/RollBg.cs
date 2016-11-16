using UnityEngine;
using System.Collections;

public class RollBg : MonoBehaviour {

    public float speed;

	void FixedUpdate () {
        gameObject.transform.Rotate(new Vector3(0, 0, speed) * Time.deltaTime);
    }
}
