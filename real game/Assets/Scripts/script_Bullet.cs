using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_Bullet : MonoBehaviour {

    Camera cam;
    Vector2 pos; 

    // Use this for initialization
    void Start () {

        cam = Camera.main;

    }
	
	// Update is called once per frame
	void Update () {

        pos = new Vector2(cam.WorldToScreenPoint(transform.position).x, cam.WorldToScreenPoint(transform.position).y);


        if (pos.x<0 || pos.x>Screen.width || pos.y<0 || pos.y>Screen.height)
        {
            Destroy(gameObject);
        }

	}

	void OnTriggerEnter2D (Collider2D other)
	{

		if (other.CompareTag ("Walls")) {
			Destroy(gameObject);
		}

	}
}
