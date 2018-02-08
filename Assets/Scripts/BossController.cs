using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {

	public GameObject Endpoint1;
	public GameObject Endpoint2;
	public float speed = .5f;

	private GameObject nextPoint;

	// Use this for initialization
	void Start () {
		
		nextPoint = Endpoint1;

	}
	
	// Update is called once per frame
	void Update () {
		
		if (transform.position == Endpoint1.transform.position) {

			nextPoint = Endpoint2;
			Flip ();
		
		} else if (transform.position == Endpoint2.transform.position) {

			nextPoint = Endpoint1;
			Flip ();
		}

		transform.position = Vector2.MoveTowards (transform.position, nextPoint.transform.position, speed * Time.deltaTime); 

	}
		
	void Flip (){
		gameObject.GetComponent<SpriteRenderer> ().flipX = 
			!gameObject.GetComponent<SpriteRenderer> ().flipX;
	}


	void OnTriggerEnter2D (Collider2D coll ) {
		if (coll.gameObject.tag == "Player") {
			
				Debug.Log ("contact");
				GameManager.Death ();
			

		}

	
	}

	private bool TurnAround (){
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, 1 << LayerMask.NameToLayer ("Midground"));

		if (hit.collider != null) {
			Debug.Log(hit.collider.name);
			return false;
		}

		return true;
	}

}
