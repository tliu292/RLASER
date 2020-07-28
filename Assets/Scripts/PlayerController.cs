using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float health = 250f;
	public float speed = 15.0f;
	public float padding = 0.5f;
	
	public GameObject projectile;
	public float projectileSpeed;
	public float firingRate = 0.2f;
	
	public AudioClip fireSound;
	public AudioClip destroyedSound;
	public AudioClip heatlhDownSound;
		
	float xMin;
	float xMax;
	
	void Start(){
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
		xMin = leftmost.x + padding;
		xMax = rightmost.x - padding;
	}
	
	void Fire(){
		GameObject beam = Instantiate(projectile, this.transform.position, Quaternion.identity) as GameObject;
		beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, projectileSpeed, 0f);
		AudioSource.PlayClipAtPoint(fireSound,transform.position);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)){
			InvokeRepeating("Fire", 0.000001f, firingRate);
		}
		if (Input.GetKeyUp(KeyCode.Space)){
			CancelInvoke("Fire");
		}
		
		if (Input.GetKey(KeyCode.RightArrow)){
			//this.transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
			this.transform.position += Vector3.right * speed * Time.deltaTime;
		}else if (Input.GetKey(KeyCode.LeftArrow)){
			//this.transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);
			this.transform.position += Vector3.left * speed * Time.deltaTime;
		}
		
		float newX = Mathf.Clamp (transform.position.x, xMin, xMax);
		this.transform.position = new Vector3(newX, this.transform.position.y, this.transform.position.z);
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		Projectile missile = collider.gameObject.GetComponent<Projectile>();
		if (missile){
			health -= missile.GetDamage();
			missile.Hit ();
			AudioSource.PlayClipAtPoint(heatlhDownSound,Health.FindObjectOfType<Health>().transform.position);
			if (health <= 0f){
				Destroyed();
			}
		}
	}
	
	void Destroyed(){
		LevelManager manager = GameObject.Find ("LevelManager").GetComponent<LevelManager>();
		manager.LoadLevel("Lose");
		Destroy (gameObject);
		AudioSource.PlayClipAtPoint(destroyedSound,transform.position);
	}
}





