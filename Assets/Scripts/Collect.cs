using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Collect : MonoBehaviour {

	public int points;
	public AudioClip clip;

	void OnTriggerEnter2D (Collider2D coll) {
		GameManager.AddScore (points);
		AudioSource.PlayClipAtPoint(clip, transform.position);
		//audio.Play ();
		Object.Destroy (gameObject);	
	}
}
