using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour {

  private string calculateNextLevel(string level) {
    int complexity = Int32.Parse(level.Split('_')[0]);
    int number = Int32.Parse(level.Split('_')[1]);

    if (number == 15 && LevelManager.difficulty != "impossible") {
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

  public void Start() {
    // If we're on the last level of a difficulty, don't display
    if (LevelManager.level == "4_15" || LevelManager.level == "9_15" || LevelManager.level == "14_15" || LevelManager.level == "19_15" || LevelManager.level == "20_33") {
      Destroy(this.gameObject);
    }
  }
}
