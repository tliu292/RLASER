using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;
	// music clips
	public AudioClip startClip;
	public AudioClip gameClip;
	public AudioClip loseClip;
	public AudioClip winClip;
	
	private AudioSource music;
	
	void Awake(){
		if (instance != null && instance != this){
			Destroy (gameObject);
			print ("Self destructing duplicate music player");
		} else{
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			/*music = GetComponent<AudioSource>();
			music.clip = startClip;
			music.loop = true;
			music.Play(); */
		}	
	}
	
/*
	void OnLevelWasLoaded(int level){
		music.Stop();
		if (level == 0) music.clip = startClip;
		if (level == 1) music.clip = gameClip;
		if (level == 2) music.clip = loseClip;
		if (level == 3) music.clip = winClip;
		music.loop = true;
		music.Play();
	}
*/
	
	// Update is called once per frame
	void Update () {
	
	}
}
