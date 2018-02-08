using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour {
	public float speed = 4;
	public float jumpForce = 400f;
	public int flip = -1; //-1 face right
//	public GameObject shot;
//	public GameObject shotSpawn;

	private Rigidbody2D rb;
	private Animator anim;
	private int moveHash;
	private Vector3 spawnPoint;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
		moveHash = Animator.StringToHash ("Moving");
		spawnPoint = transform.position;



	}

	void Update () {
		if (GameManager.state != GameManager.GameState.playing) {
			return;
		}

		//get horizontal input
		float x = Input.GetAxis ("Horizontal");

		if (Mathf.Abs(x) < .05) {
			anim.SetBool (moveHash, false);
		} else {
			anim.SetBool (moveHash, true);
		}

		//move grant by incrmenet
		rb.velocity = new Vector2(x * speed * Time.deltaTime, rb.velocity.y);

		//flip sprite?
		if (x < 0) {
			Vector3 scale = transform.localScale; 
			scale.x = -1 * flip; 
			transform.localScale = scale;
		} else if (x > 0) {
			Vector3 scale = transform.localScale; 
			scale.x = flip; 
			transform.localScale = scale;
		}

		if (Input.GetKeyDown(KeyCode.Space) && Grounded() ) { 
			AudioSource audio = GetComponent<AudioSource>();
			rb.AddForce (new Vector2 (0, jumpForce));
			audio.Play ();
		}

//		if (Input.GetButton("Fire2")) {
//		
//			Instantiate(shot, shotSpawn.transform.position, shotSpawn.transform.rotation);
//		
//		}
		
		
	}

	public void Respawn () {
		transform.position = spawnPoint;
	}

	private bool Grounded () {
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, 1 << LayerMask.NameToLayer ("Midground"));

		if (hit.collider != null) {
			return true;
		}

		return false;
			
	}
}
