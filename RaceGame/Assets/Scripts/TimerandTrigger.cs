using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerandTrigger : MonoBehaviour {

	public Text timerLabel;

	private float time;
	private bool finished;
	private bool isPaused;

	void Update()
	{
		isPaused = false;
		if (!finished && !isPaused)
        {
			time += Time.deltaTime;

			float minutes = Mathf.Floor(time / 60);
			float seconds = Mathf.Floor(time % 60);
			float fraction = Mathf.Floor(time * 100) % 100;

			timerLabel.text = string.Format("{0:00} : {1:00} : {2:000}", minutes, seconds, fraction);
		}
	}

	void OnTriggerEnter () 
	{
		finished = true;
		isPaused = true;
	}

	void OnGUI () {

		if (finished)
		{
			isPaused = true;

			if (time <= 120) 
			{
				GUI.Label (new Rect (10, 50, 100, 20), "Finished!");
			}
			else if (time > 120)
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