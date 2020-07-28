using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {
	public static int score;
	private Text myText;
	public AudioClip scoreUpSound;
		
	void Start(){
		myText = GetComponent<Text>();
		myText.text = score.ToString ();
	}
	
	public int getScore() { return score;}
	
	public void Score(int points){
		score += points;
		myText.text = score.ToString();
		AudioSource.PlayClipAtPoint(scoreUpSound,transform.position);
	}
	
	public static void Reset(){
		score = 0;
	}
}
