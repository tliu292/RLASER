using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public GameObject projectile;
	public float projectileSpeed = 10f;
	public float health = 150f;
	public float shotsPerSeconds = 0.5f;
	public int enemyScore = 150;
	public float hitPoints;
	
	// Sound Effects
	public AudioClip fireSound;
	public AudioClip destroyedSound;
	
	private ScoreKeeper scoreKeeper;
	
	void Start(){
		scoreKeeper = GameObject.Find ("Score").GetComponent<ScoreKeeper>();
		hitPoints = health;
	}
	
	void Update(){
		float probability = Time.deltaTime * shotsPerSeconds;
		if (Random.value < probability){
			Fire ();
		}
	}
	
	void Fire(){
		GameObject beam = Instantiate(projectile, this.transform.position, Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -projectileSpeed);
		AudioSource.PlayClipAtPoint(fireSound,transform.position);
	}

	void OnTriggerEnter2D(Collider2D collider){
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		if (missile){
			health -= missile.GetDamage();
			missile.Hit ();
			if (health <= 0f){
				Destroy (gameObject);
				scoreKeeper.Score(enemyScore);
				if (scoreKeeper.getScore() >= 5000 && scoreKeeper.getScore() <= 5100){
					Application.LoadLevel("Game 2");
				}
				if (scoreKeeper.getScore() >= 10000 && scoreKeeper.getScore() <= 10200){
					Application.LoadLevel("Game 3");
				}
				if (scoreKeeper.getScore() >= 15000 && scoreKeeper.getScore() <= 15250){
					Application.LoadLevel("Game 4");
				}
				if (scoreKeeper.getScore() >= 20000 && scoreKeeper.getScore() <= 20300){
					Application.LoadLevel("Game 5");
				}
				if (scoreKeeper.getScore() >= 25000){
					Application.LoadLevel("Win");
				}
				AudioSource.PlayClipAtPoint(destroyedSound,transform.position);
			}
		}
	}
}
