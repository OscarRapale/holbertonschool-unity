using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour {

	public Timer timer;
	public Text timerText;

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("Player reached WinFlag!");
		if (other.CompareTag("Player")) // Check if player touches WinFlag
		{
			timer.StopTimer(); //Stop timer
		
			// Change properties
			timerText.fontSize = 60;
			timerText.color = Color.green;
		}
	}
}
