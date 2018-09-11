using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour {

  private string calculateNextDifficulty(string level) {
    switch(level) {
      case "4_15":
        return "medium";
      case "9_15":
        return "hard";
      case "14_15":
        return "master";
      case "19_15":
        return "impossible";
    }
    return "easy";
  }

  private string calculateNextLevel(string level) {
    int complexity = Int32.Parse(level.Split('_')[0]);
    int number = Int32.Parse(level.Split('_')[1]);

    if (number == 15 && GameManager.difficulty != "impossible") {
      return (complexity+1).ToString() + "_1";
    } else {
      return complexity.ToString() + "_" + (number+1).ToString();
    }
  }
  
  public void onNextLevelClick() {
    string level = GameManager.level;
    GameManager.difficulty = calculateNextDifficulty(level);
    GameManager.level = calculateNextLevel(level);
    GameManager.Load("Game");
  }
}
