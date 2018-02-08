using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {


	private string switchName;

	private bool switch3;

	void Start () {
		switch3 = false;
	
	} 

	void Update () {
		if (switch3) {
			PlatformInit.SingleTurnOn ();
		}
	}
	
	void OnTriggerEnter2D (Collider2D coll ) {
		if (coll.gameObject.tag == "Player") {
			
			if (GameManager.level == 4) {
				
				switchName = this.name;

				PlatformInit.MultipleTurnOn (switchName);

			}


			if (GameManager.level == 3) {
				Debug.Log("switch on 3 collided");
				switch3 = !switch3;

			}

		}
			

	}
		
}
