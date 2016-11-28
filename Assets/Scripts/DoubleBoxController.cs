using UnityEngine;
using System.Collections;

public class DoubleBoxController : MonoBehaviour
{
    public GameObject globalboomExample;

    public void DestroyBox()
    {
        var temp = gameObject.transform.parent.GetComponent<Box>();
        temp.ForienBox.Remove(gameObject);

        var boxes = GameObject.Find("Boxes");

        var boomSpr = (GameObject)Instantiate(globalboomExample, transform.position, transform.rotation);
        boomSpr.transform.parent = boxes.transform;
        Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<CircleCollider2D>())
        {
            if (col.GetComponent<CircleCollider2D>().tag == "Player")
            {
                col.GetComponent<Controll>().KillCat();

                DestroyBox();   
            }
        }
    }

}