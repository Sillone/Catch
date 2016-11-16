using UnityEngine;
using System.Collections;

public class laser : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<BoxCollider2D>())
        {
            if (col.GetComponent<BoxCollider2D>().tag == "Wall")
            {
                Debug.Log("laser in box!");
            }
        }
    }
}