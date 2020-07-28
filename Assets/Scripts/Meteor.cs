using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float xVelocity = Random.Range (-0.1f,0.1f);
		float yVelcoity = Random.Range(-0.1f,0.1f);
		this.GetComponent<Rigidbody2D>().velocity += new Vector2(xVelocity,yVelcoity);
	}
}
