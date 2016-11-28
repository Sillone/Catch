using UnityEngine;
using System.Collections;

public class Controll : MonoBehaviour
{
    public int HP;

    public float jumpForce;

    public int level;
    
    public Transform groundCheck;

    private float groundRadius;
    private float boxRadius;

    private Animator myAnimator;

    private string catStateName;

    private GameObject Boxes;

    private Rigidbody2D RigBody;

    private Transform trans;

    private CreateBox _CreateBox;

    void Start()
    {
        HP = 1;
        trans = transform;
        RigBody = GetComponent<Rigidbody2D>();
        Boxes = GameObject.Find("Boxes");

        switch (level)
        {
            case 1:
                {
                    catStateName = "isGrounded";
                    break;
                }
            case 2:
                {
                    catStateName = "batGrounded";
                    break;
                }
            case 3:
                {
                    catStateName = "supGrounded";
                    break;
                }
            default:
                catStateName = "UnKnownCat";
                break;
        }

        myAnimator = GetComponent<Animator>();

        myAnimator.SetBool(catStateName, true);

        groundRadius = 0.39f;
        boxRadius = 0.68f;
        _CreateBox = Boxes.GetComponent<CreateBox>();        
    }

    private bool CheckGrounded()
    {
        float distGround = Vector2.Distance(groundCheck.position, trans.position);

        if (distGround < groundRadius)
        {
            myAnimator.SetBool(catStateName, true);
            return true;
        }
        else
        {
            foreach (var box in _CreateBox.ExistedBoxes)
            {
                float distBox = Vector2.Distance(box.transform.position, trans.position);
                if (box.transform.position.y < -0.9f && distBox < boxRadius)
                {
                    myAnimator.SetBool(catStateName, true);
                    return true;
                }

            }
            myAnimator.SetBool(catStateName, false);
            return false;
        }
    }

    void Update()
    {
        ClickJump();
    }

    private void ClickJump()
    {
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || (Input.GetKeyDown(KeyCode.Space)))
        {
            if (CheckGrounded())
            {
                RigBody.AddForce(new Vector2(0f, jumpForce));
                myAnimator.SetBool(catStateName, false);
            }
        }
    }

    public void KillCat()
    {
        HP--;
        print("cat is dying! OMG! Sasha, cho delat'?");
    }
}
