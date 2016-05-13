using UnityEngine;
using System.Collections;

public class Controll : MonoBehaviour {

    Rigidbody2D rig;
    public GameObject catGO;
    public float jumpForce = 0f;
    float posX, posY;
    public int state;

    bool facingRight = true;
    public bool grounded = false;
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    public float dist;

    void Start () {
        rig = GetComponent<Rigidbody2D>();
        posX = rig.position.x;
        posY = rig.position.y;
        state = 0;
    }

    void Update () {

        /*if (state == 0)       //можно прыгать, мы не в воздухе
        {
            Debug.Log("can jump");
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                rig.AddForce(new Vector3(0, jumpForce, 0));
                state = 1;s
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rig.AddForce(new Vector3(0, jumpForce, 0));
                state = 1;
            }
        }
        else
        {
            Debug.Log("can't jump");
        }*/
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
      //  dist = Vector3.Distance(groundCheck.position, catGO.transform.position);
        //col.GetComponent<BoxCollider2D>().tag
      //  catGO.collider2D.GetComponent<BoxCollider2D>().tag;
            if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || (Input.GetKeyDown(KeyCode.Space)))
        {
            Debug.Log("you've tried(");
            
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

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.GetComponent<BoxCollider2D>().tag == "Wall") {
            rig.position = new Vector2(posX,0);
        }
    }

  /*  void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.gameObject.name == "dieCollider") || (col.gameObject.name == "saw"))
            Application.LoadLevel(Application.loadedLevel);


        if (col.gameObject.name == "endLevel")
        {
            if (!(GameObject.Find("star"))) Application.LoadLevel("scene2");
        }
    }*/

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