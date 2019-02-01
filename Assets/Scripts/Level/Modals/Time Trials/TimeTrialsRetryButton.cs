using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeTrialsRetryButton : MonoBehaviour {
  public void onRetryClick() {
    LevelManager.level = LevelUtility.calculateTimeTrialLevel();
    LevelManager.currentSolved = 0;
    GameManager.Load("Game");
  }
}
