using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviousLevel : MonoBehaviour {

  private string calculatePreviousLevel(string level) {
    int complexity = Int32.Parse(level.Split('_')[0]);
    int number = Int32.Parse(level.Split('_')[1]);

    if (number == 1) {
      return (complexity-1).ToString() + "_10";
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
    if (GameManager.gameType == "ranked" || LevelManager.level == "0_1" || LevelManager.level == "4_1" || LevelManager.level == "8_1" || LevelManager.level == "12_1" || LevelManager.level == "16_1") {
      Destroy(this.gameObject);
    }
  }
}
