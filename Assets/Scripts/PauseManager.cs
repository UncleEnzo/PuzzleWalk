using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour {
	
	public bool paused = false;
	public Text PauseUnpause;
	public GameObject pauseTitle;
	public Button Resume;
	
	void Start () {
		PauseUnpause.text = "Pause";
		pauseTitle.SetActive(false);
	}
	
	void Update () {
		if (paused == false){
			PauseUnpause.text = "Pause";
			pauseTitle.SetActive(false);
			Resume.onClick.AddListener(OnClickPause);
		}
	}
	
	public void OnClickPause () {
		paused = true;
	}
	
	public void OnClickUnpause () {
		paused = false;
	}
	
	void OnGUI () {
		if (paused) {
			Time.timeScale = 0;
			pauseTitle.SetActive(true);
			PauseUnpause.text = "Resume";
			Resume.onClick.AddListener(OnClickUnpause);	
		}
		else {
			Time.timeScale = 1;
		}
	}
}