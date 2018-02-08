using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class GameManager : MonoBehaviour {
    public enum GameState { menu, playing, paused, gameover, win };

    public static int level = 1;
    public static int score = 0;
    public static int lives = 3;
    public static GameState state;
	public static GameObject player;

    //UI elements
    public Text scoreText;
    public Text levelText;
    public GameObject pausedTextObject;
    public GameObject gameoverTextObject;
	public GameObject youWin;
    public Image[] lifeIcons;

	public float targetTime = 10.0f;
	private GameObject big;

    // Use this for initialization
    void Start () {
		big = GameObject.Find("BigHungry");
        state = GameState.playing;
		player = GameObject.FindGameObjectWithTag ("Player");

		if (level > 1) {
			AudioSource audio = GetComponent<AudioSource>();
			audio.Play ();

		}
	}
    
    // Update is called once per frame
    void Update () {
        levelText.text = "Level " + level;
		scoreText.text = "" + score;

		for (int i = 0; i < lifeIcons.Length; i++) {
			if (i < lives - 1) {
				lifeIcons [i].enabled = true;
			} else {
				lifeIcons [i].enabled = false;
			}
		}

        if (Input.GetKeyDown (KeyCode.Escape)) {
            if (state == GameState.playing) {
                Time.timeScale = 0;
                state = GameState.paused;
            } else if (state == GameState.paused) {
                Time.timeScale = 1;
                state = GameState.playing;
            }
        }

        if (state == GameState.playing) {
	        pausedTextObject.SetActive(false);
	            gameoverTextObject.SetActive(false);
	            
        } else if (state == GameState.paused) {
	    	pausedTextObject.SetActive(true);
        } else if (state == GameState.gameover) {
	        gameoverTextObject.SetActive (true);
	    }

        //check if time has expired?
		targetTime -= Time.deltaTime;

		if ( level == 5 && targetTime <= 0.0f) {
			Destroy (big);
			youWin.SetActive (true);
		}
    }

    public static void AddScore (int points) {
        score += points;
    }

	public static void Death() {
        //decrement lives
        lives--;

        //if lives == 0 
        if (lives <= 0) {
	        state = GameState.gameover;
        } else {
            //GameObject player = GameObject.FindGameObjectWithTag ("Player");
            //move player at starting point
            player.SendMessage("Respawn");
            //move the camera immediately to player position
            Camera.main.transform.position = new Vector3 (
                player.transform.position.x,
                player.transform.position.y,
                Camera.main.transform.position.z
            );
        }

        //screen shake
        FollowCam cam = Camera.main.GetComponent<FollowCam> ();
        if (cam != null) {
	        cam.Shake ();
	    }
	}

    public static void NextLevel () {
        level++;
        SceneManager.LoadScene ("Level" + level);
		
    }
}