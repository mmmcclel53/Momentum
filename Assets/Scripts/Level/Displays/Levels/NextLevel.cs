using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour {

  private string calculateNextLevel(string level) {
    int complexity = Int32.Parse(level.Split('_')[0]);
    int number = Int32.Parse(level.Split('_')[1]);

    if (number == 10) {
      return (complexity+1).ToString() + "_1";
    } else {
      return complexity.ToString() + "_" + (number+1).ToString();
    }
  }
  
  public void onNextLevelClick() {
    string level = LevelManager.level;
    LevelManager.level = calculateNextLevel(level);
    GameManager.Load("Game");
  }

  void Start() {
    // If ranked or we're on the last level of a difficulty, don't display
    if (GameManager.gameType == "ranked" || GameManager.gameType == "time_trials" || LevelManager.level == "3_10" || LevelManager.level == "7_10" || LevelManager.level == "11_10" || LevelManager.level == "15_10" || LevelManager.level == "19_10") {
      Destroy(this.gameObject);
    }
  }
}
