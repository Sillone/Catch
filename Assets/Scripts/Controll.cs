using UnityEngine;
using System.Collections;

public class Controll : MonoBehaviour
{
    public float jumpForce;

    public int level;

    public bool grounded;
    public Transform groundCheck;

    private float groundRadius;
    private float boxRadius;

    private float distGround;

    private Animator myAnimator;

    private string catStateName;

    private GameObject Boxes;

    private Rigidbody2D RigBody;

    void Start()
    {
        RigBody = GetComponent<Rigidbody2D>();
        Boxes = GameObject.Find("Boxes");
        if (level == 1)
        {
            catStateName = "isGrounded";
        }
        else if(level == 2)
        {
            catStateName = "batGrounded";
        }
        else if(level ==3)
        {
            catStateName = "supGrounded";
        }
        myAnimator = GetComponent<Animator>();

        grounded = true;
        myAnimator.SetBool(catStateName, true);

        groundRadius = 0.39f;
        boxRadius = 0.68f;        
    }

    private void CheckGrounded()
    {
        distGround = Vector2.Distance(groundCheck.position, gameObject.transform.position);

        if (distGround < groundRadius)
        {
            myAnimator.SetBool(catStateName, true);
            grounded = true;
            ClickJump();
        }
        else
        {
            grounded = false;
            myAnimator.SetBool(catStateName, false);

            foreach (var box in Boxes.GetComponent<CreateBox>().ExistedBoxes)
            {
                float distBox = Vector2.Distance(box.transform.position, gameObject.transform.position);
                if (distBox < boxRadius && box.transform.position.y < -0.9f)
                {
                    grounded = true;
                    myAnimator.SetBool(catStateName, true);
                    ClickJump();
                    break;
                }
            }
        }
    }

    void Update()
    {
        CheckGrounded();
    }

    private void ClickJump()
    {
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || (Input.GetKeyDown(KeyCode.Space)))
        {
            RigBody.AddForce(new Vector2(0f, jumpForce));
            grounded = false;
            myAnimator.SetBool(catStateName, false);
        }
    }

    public void KillCat()
    {
        print("cat is dying! OMG! Sasha, cho delat'?");
    }
}
