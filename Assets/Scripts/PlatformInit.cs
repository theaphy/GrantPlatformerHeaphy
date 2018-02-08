using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformInit : MonoBehaviour {

	public GameObject Endpoint1;
	public GameObject Endpoint2;
	public static float speed;

	private static string current;

	private static GameObject nextPoint;
	private static GameObject plat;

	private static GameObject gamey;

	// Use this for initialization
	void Start () {
		plat = GameObject.Find ("Platform");
		nextPoint = Endpoint1;
		gamey = GameObject.FindGameObjectWithTag ("MamaPlat");

		//GameManager.level = 3; //REMOVE IF YOU ARENT WORKING ON LEVEL 3

	}
	
	// Update is called once per frame
	void Update () {
		if (plat.transform.position == Endpoint1.transform.position) {

			nextPoint = Endpoint2;

		} else if (plat.transform.position == Endpoint2.transform.position) {

			nextPoint = Endpoint1;

		}
	}

	public static void SingleTurnOn () {

		speed = 1;

		plat.transform.position = Vector2.MoveTowards (plat.transform.position, nextPoint.transform.position, 
			speed * Time.deltaTime); 
		
	}

	public static void MultipleTurnOn (string platName) {

		gamey = GameObject.Find ("Plat" + platName);
		gamey.transform.position = new Vector2(0, gamey.transform.position.y);
	
	}
}
