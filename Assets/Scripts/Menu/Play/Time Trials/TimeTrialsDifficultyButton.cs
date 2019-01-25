using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TimeTrialsDifficultyButton : MonoBehaviour {
  public void onDifficultyClick(string difficulty) {
    LevelManager.difficulty = difficulty;
    LevelManager.level = LevelUtility.calculateTimeTrialLevel();
    LevelManager.currentSolved = 0;
    GameManager.Load("Game");
	}
}
