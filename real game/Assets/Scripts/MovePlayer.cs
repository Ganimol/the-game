using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

    //Velocity
    private float vUp;
    private float vHor;

    public float moveSpd = 5;
	public float jmp = 8;
	public float bulletSpd = 550;
	public float recoil = 15;
	public float recoilDrag = 10; 


    private bool isGrounded = false;

    //Other stuff
    private Rigidbody2D rb2d;
    Camera cam;

    public GameObject bullet;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    // Use this for initialization
    void Start () {

        rb2d = GetComponent<Rigidbody2D>();
        cam = Camera.main;

    }
	
	// Update is called once per frame
	void Update () {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.15f, whatIsGround);

        //Movement
        if (Input.GetKey(KeyCode.A))

        {

            vHor = -moveSpd;

        }
        else if (Input.GetKey(KeyCode.D))
        {

            vHor = moveSpd;

        }
        else
        {

            vHor = 0f;

        }

        if (Input.GetKeyDown(KeyCode.W))

        {
			if (isGrounded)
            vUp = jmp;

        }
        else
        {

            vUp = 0;

        }

        //use this code for aimed bullets
        ///*
        if (Input.GetMouseButtonDown(0))

        {
            if (GameObject.FindGameObjectsWithTag("bullet").Length < 3)

            { 
                
                Vector2 bulletDirection = new Vector2(Input.mousePosition.x - cam.WorldToScreenPoint(transform.position).x, Input.mousePosition.y - cam.WorldToScreenPoint(transform.position).y);
                bulletDirection.Normalize();
                GameObject b = (GameObject)(Instantiate(bullet, transform.position, Quaternion.identity));
                b.GetComponent<Rigidbody2D>().AddForce(bulletDirection * bulletSpd);
				rb2d.AddForce (-bulletDirection*recoil); 

                
            }
        }
        //*/

        //Use this code for cardinal direction bullets
        /*
        if(Input.GetKeyDown(KeyCode.LeftArrow) && GameObject.FindGameObjectsWithTag("bullet").Length < 3)
          
        {
          
             GameObject b = (GameObject)(Instantiate(bullet, transform.position, Quaternion.identity));
             b.GetComponent<Rigidbody2D>().AddForce(new Vector2(-bulletSpd,0));
         
        }
         
        if(Input.GetKeyDown(KeyCode.RightArrow) && GameObject.FindGameObjectsWithTag("bullet").Length < 3)
         
        {
        
             GameObject b = (GameObject)(Instantiate(bullet, transform.position, Quaternion.identity));
             b.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletSpd,0));
        
        }
          
        if(Input.GetKeyDown(KeyCode.UpArrow) && GameObject.FindGameObjectsWithTag("bullet").Length < 3)
          
        {
          
            GameObject b = (GameObject)(Instantiate(bullet, transform.position, Quaternion.identity));
            b.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,bulletSpd));
         
        }
          
        if(Input.GetKeyDown(KeyCode.DownArrow) && GameObject.FindGameObjectsWithTag("bullet").Length < 3)
         
        {
          
            GameObject b = (GameObject)(Instantiate(bullet, transform.position, Quaternion.identity));
            b.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,-bulletSpd));
          
        }
        */
        
    }

    void FixedUpdate () {

		transform.position = transform.position + new Vector3 (vHor, 0, 0); 
		if (rb2d.velocity.x > 0) {
			rb2d.velocity = new Vector2 (Mathf.Max (rb2d.velocity.x - recoilDrag, 0), rb2d.velocity.y + vUp);
		}
		else if (rb2d.velocity.x < 0) {
			rb2d.velocity = new Vector2 (Mathf.Min (rb2d.velocity.x + recoilDrag, 0), rb2d.velocity.y + vUp);
		}
		else {
			rb2d.velocity = new Vector2 (0, rb2d.velocity.y + vUp);
		}
    }
}
