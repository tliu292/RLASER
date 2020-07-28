using UnityEngine;
using System.Collections;

public class FormationController : MonoBehaviour {
	public GameObject enemyPrefab; // enemy picture
	public float width = 7f; // width of the gizmo box
	public float height = 5f; // height of the gizmo box
	private bool movingRight = true; // direction of all enemies
	public float speed = 5f; // speed of all enemies
	public float spawnDelay = 0.5f; // time between each appearing enemy
		
	// Restricts the enemy's position
	private float xMin;
	private float xMax;
	
	// Use this for initialization
	void Start () {
		// Calculate the left and right edges
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		Vector3 rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
		xMin = leftEdge.x;
		xMax = rightEdge.x;
		
		// Spawn enemies one-by-one
		SpawnUntilFull();
	}
		
	// Update is called once per frame
	void Update () {
		// Enemies move right or left according to movingRight variable
		if (movingRight){
			this.transform.position += Vector3.right * speed * Time.deltaTime;
		} else{
			this.transform.position += Vector3.left * speed * Time.deltaTime;
		}
		
		// Ensure that enemies do not goes off boundaries
		// Check whether it's going outside the playspace
		float rightEdgeOfFormation = this.transform.position.x + (0.5f * width); 
		float leftEdgeOfFormation = this.transform.position.x - (0.5f * width);
		if (rightEdgeOfFormation > xMax){
			movingRight = false;
		} else if (leftEdgeOfFormation < xMin){
			movingRight = true;
		}
		
		// Spawn enemies when all are destroyed by player
		if (AllMembersDead()){
			SpawnUntilFull();
		}
	}
	
	// All enemies are within this gizmo cube 
	// Convenient for editing
	public void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}
	
	// NO LONGER USING
	// REPLACED BY SpawnUntilFull() method
	// Spawn all enemies at start or when all enemies are dead
	void SpawnEnemies(){
		foreach(Transform child in transform){	
			GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}
	
	// Spawn the enemy one by one instead of all at once
	void SpawnUntilFull(){
		Transform freePosition = NextFreePosition();
		if (freePosition){
			GameObject enemy = Instantiate(enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePosition;
		}
		// Spawn the enemy only if there's enemy position being empty
		if (NextFreePosition()){
			Invoke ("SpawnUntilFull", spawnDelay);
		}
	}
	
	// Check whether the specified position is empty
	// if it is, return the position; otherwise, return nothing
	// meaning that the position needs to refill an enemy if it's being destroyed by player
	Transform NextFreePosition(){
		foreach(Transform childPositionGameObject in this.transform){
			if (childPositionGameObject.childCount == 0) return childPositionGameObject;
		}
		return null;
	}
	
	// Check whether there's still enemies in playspace
	bool AllMembersDead(){
		// transform.childCount is expected to be 6
		// since there's 6 children(positions) within EnemyFormation
		foreach(Transform childPositionGameObject in this.transform){
			if (childPositionGameObject.childCount > 0) { return false; }
		}
		return true;
	}
}




