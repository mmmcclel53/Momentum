using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviousLevel : MonoBehaviour {

  private string calculatePreviousLevel(string level) {
    int complexity = Int32.Parse(level.Split('_')[0]);
    int number = Int32.Parse(level.Split('_')[1]);

    if (number == 1 && LevelManager.difficulty != "impossible") {
      return (complexity-1).ToString() + "_15";
    } else {
      return complexity.ToString() + "_" + (number-1).ToString();
    }
  }
  
  public void onPreviousLevelClick() {
    string level = LevelManager.level;
    LevelManager.level = calculatePreviousLevel(level);
    GameManager.Load("Game");
  }

  void Start() {
    // If ranked or we're on the first level of a difficulty, don't display
    if (GameManager.gameType == "ranked" || LevelManager.level == "0_1" || LevelManager.level == "5_1" || LevelManager.level == "10_1" || LevelManager.level == "15_1" || LevelManager.level == "20_1") {
      Destroy(this.gameObject);
    }
  }
}
