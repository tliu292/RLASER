using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour {

	private Text myText;
	PlayerController playerController;
	float health;

	// Use this for initialization
	void Start () {
		myText = GetComponent<Text>();
		myText.text = health.ToString ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectWithTag("Player 1")){
			playerController = GameObject.FindGameObjectWithTag("Player 1").GetComponent<PlayerController>();
		}if (GameObject.FindGameObjectWithTag("Player 2")){
			playerController =  GameObject.FindGameObjectWithTag("Player 2").GetComponent<PlayerController>();
		}if (GameObject.FindGameObjectWithTag("Player 3")){
			playerController =  GameObject.FindGameObjectWithTag("Player 3").GetComponent<PlayerController>();
		}
		health = playerController.health;
		myText.text = health.ToString();
	}
}
