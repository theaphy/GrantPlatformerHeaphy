using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackAndForth : MonoBehaviour {

	public GameObject Endpoint1;
    public GameObject Endpoint2;
    public float speed = .5f;

	private GameObject nextPoint;

    void Start() {
	        nextPoint = Endpoint1;
	    }

    // Update is called once per frame
    void Update () {
        if (transform.position == Endpoint1.transform.position) {
            nextPoint = Endpoint2;

			if (gameObject.GetComponent<SpriteRenderer> ()) {
				Flip ();    
			}
              
		} else if (transform.position == Endpoint2.transform.position) {
            nextPoint = Endpoint1;

			if (gameObject.GetComponent<SpriteRenderer> ()) {
				Flip ();    
			}  
		}
        transform.position = Vector2.MoveTowards (transform.position, nextPoint.transform.position, 
            speed * Time.deltaTime); 
    }

	void Flip (){
	        gameObject.GetComponent<SpriteRenderer> ().flipX = 
		            !gameObject.GetComponent<SpriteRenderer> ().flipX;
	}

}
