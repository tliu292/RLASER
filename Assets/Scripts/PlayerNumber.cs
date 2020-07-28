using UnityEngine;
using System.Collections;

public class PlayerNumber : MonoBehaviour {
	public static int playerNumber;
	void Start () {
		playerNumber = Application.loadedLevel - 2;
	}
}
