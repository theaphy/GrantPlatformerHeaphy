using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

	private Rigidbody2D rb;
	public float speed;

	private GameObject big;

	void Start () {
		big = GameObject.Find ("BigHungry");

		rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2(big.transform.position.x, big.transform.position.y) * speed;
	}
}