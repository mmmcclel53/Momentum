using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour {

  public GameObject levelsScrollView;

  private int[] getCurrentStars(string difficulty) {
    switch (difficulty) {
      case "easy":
        return GameManager.easyStars;
      case "medium":
        return GameManager.mediumStars;
      case "hard":
        return GameManager.hardStars;
      case "master":
        return GameManager.masterStars;
      case "impossible":
        return GameManager.impossibleStars;
      default:
        return GameManager.easyStars;
    }
  }

  public void onDifficultyClick(string difficulty) {
    LevelManager.difficulty = difficulty;
    GameManager.currentStars = getCurrentStars(difficulty);
    int levels = 75;
    if (difficulty == "impossible") {
      levels = 33;
    }
    levelsScrollView.GetComponent<Mosframe.DynamicVScrollView>().totalItemCount = levels;
	}
}
