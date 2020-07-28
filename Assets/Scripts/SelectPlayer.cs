using UnityEngine;
using System.Collections;

public class SelectPlayer : MonoBehaviour {
	private int playerIndex;
	private GameObject[] players;
	public GameObject player1Prefab;
	public GameObject player2Prefab;
	public GameObject player3Prefab;
	
	// Use this for initialization
	void Start () {
		players = new GameObject[] {player1Prefab, player2Prefab, player3Prefab};
		playerIndex = PlayerNumber.playerNumber;
		Vector3 position = new Vector3(0f, -4f, 0f);
		Instantiate(players[playerIndex], position, Quaternion.identity);
	}
}
