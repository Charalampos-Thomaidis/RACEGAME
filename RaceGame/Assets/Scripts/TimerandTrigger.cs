using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerandTrigger : MonoBehaviour {

	public Text timerLabel;

	private float time;
	private bool finished;

	void Update()
	{
		time += Time.deltaTime;

		float minutes = time / 60;
		float seconds = time % 60;
		float fraction = (time * 100) % 100;

		timerLabel.text = string.Format ("{0:00} : {1:00} : {2:000}", minutes, seconds, fraction);
	}

	void OnTriggerEnter () 
	{
		finished = true;
	}

	void OnGUI () {

		if (finished) 
		{
			if (time <= 120) 
			{
				GUI.Label (new Rect (10, 50, 100, 20), "Finished!");
			}
			else
			{
				GUI.Label (new Rect (10, 50, 100, 20), "Not finished!");
			}
			if (GUI.Button (new Rect (10, 100, 300, 40), "Restart Game")) 
			{
				SceneManager.LoadScene(1);
			}
			if (GUI.Button (new Rect (10, 150, 300, 40), "Exit")) 
			{
				SceneManager.LoadScene(0);
			} 
		}
	}
}