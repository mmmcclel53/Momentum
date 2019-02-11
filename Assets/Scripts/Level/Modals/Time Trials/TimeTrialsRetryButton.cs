using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeTrialsRetryButton : MonoBehaviour {
  public void onRetryClick() {
    LevelManager.time = 0;
    LevelManager.currentSolved = 0;
    LevelManager.paused = false;
    LevelManager.level = LevelUtility.calculateTimeTrialLevel();
    GameManager.Load("Game");
  }
}
