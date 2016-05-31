using UnityEngine;
using System.Collections;

public class Controll : MonoBehaviour
{

    protected Rigidbody2D rig;
    public GameObject catGO;
    public float jumpForce = 0f;
    protected float posX, posY;

    public int level;

    public bool grounded = true;
    public Transform groundCheck;

    protected float groundRadius;
    protected float boxRadius;

    protected float distGround;
    protected float[] distBox;

    protected Animator myAnimator;

    protected void Start()
    {
        myAnimator = GetComponent<Animator>();

        grounded = true;
        myAnimator.SetBool("isGround", true);

        rig = GetComponent<Rigidbody2D>();
        posX = rig.position.x;
        posY = rig.position.y;
        groundRadius = 0.39f;
        boxRadius = 0.68f;        

        distBox = new float[5];
    }
        
    protected virtual void Update()
    {
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || (Input.GetKeyDown(KeyCode.Space)))
        {
            ////can we fucking jump?
            distGround = Vector2.Distance(groundCheck.position, catGO.transform.position);
            if (distGround < groundRadius)
            {

                myAnimator.SetBool("isGround", true);
                grounded = true;
            }
            else
            {
                grounded = false;
                myAnimator.SetBool("isGround", false);
                for (int i = 0; i < 5; i++)
                {
                    if (GameObject.Find("myBox" + i))
                    {
                        distBox[i] = Vector2.Distance(GameObject.Find("myBox" + i).transform.position, catGO.transform.position);
                        if (distBox[i] < boxRadius && GameObject.Find("myBox" + i).transform.position.y < -0.9f)
                        {
                            grounded = true;
                            myAnimator.SetBool("isGround", true);
                            break;
                        }
                    }
                }
            }//now we know this

            if (grounded)
            {
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, jumpForce));
            }
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    protected void OnTriggerEnter2D(Collider2D col)
    {

        if (col.GetComponent<BoxCollider2D>().tag == "Wall")
        {
            rig.position = new Vector2(posX, 0);
        }
    }

}


   /* using UnityEngine;
using System.Collections;

public class characterController : MonoBehaviour {
	public float maxSpeed = 10f;
	public float jumpForce = 700f;
	bool facingRight = true;
	bool grounded = false;
	public Transform groundCheck;
	public float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float score;
	public float move;

	private GameObject star;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {


		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

		move = Input.GetAxis ("Horizontal");

	}

	void Update(){
		if (grounded && (Input.GetKeyDown (KeyCode.W)||Input.GetKeyDown (KeyCode.UpArrow))) {

			GetComponent<Rigidbody2D>().AddForce (new Vector2(0f,jumpForce));
		}
		GetComponent<Rigidbody2D>().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
		
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();



		if (Input.GetKey(KeyCode.Escape))
		{
			Application.Quit();
		}

		if (Input.GetKey(KeyCode.R))
		{
			Application.LoadLevel(Application.loadedLevel);
		}


	}
	
	void Flip(){
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnTriggerEnter2D(Collider2D col){
		if ((col.gameObject.name == "dieCollider")||(col.gameObject.name == "saw"))
						Application.LoadLevel (Application.loadedLevel);

	    if (col.gameObject.name == "star") {
						score++;
						Destroy (col.gameObject);
				}

		if (col.gameObject.name == "endLevel") {
			if (!(GameObject.Find("star"))) Application.LoadLevel ("scene2");
				}
	}

	void OnGUI(){
				GUI.Box (new Rect (0, 0, 100, 100), "Stars: " + score);
		}
		
}


    */