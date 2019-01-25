using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnRankedQuit : MonoBehaviour {

	private const int rankedPenalty = -15;

	public void onRankedQuit() {
		GameManager.adjustRankedExperience(rankedPenalty);
		GameManager.Load("MainMenu");
	}

	public void onCancel() {
		LevelManager.paused = false;
	}
}
