using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
	
	public AudioClip[] levelMusicChangeArray;
	
	private AudioSource audioSource;
	
	void Awake () {
		DontDestroyOnLoad(gameObject);	
	}
	
	void Start () {
		audioSource = GetComponent<AudioSource>();
	}
	
	public void ChangeVolume(float volume){
		if (volume >= 0f && volume <=1f) {
			audioSource.volume = volume;
		}
		else {
			Debug.Log ("Volume outside of acceptable ranges");
		}
	}
	
	// Update is called once per frame
	void OnLevelWasLoaded (int level) {
		AudioClip thisLevelMusic = levelMusicChangeArray[level];		
		if (thisLevelMusic) { // if there's some music attached
			audioSource.clip = thisLevelMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
	}
}
