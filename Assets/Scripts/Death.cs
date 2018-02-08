using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Death : MonoBehaviour {

	public AudioClip clip;

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Player"){
			AudioSource.PlayClipAtPoint(clip, transform.position);
			GameManager.Death ();
		} else {
			Object.Destroy (col.gameObject);
		}
	}
}
