using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour {
  
  public GameObject DifficultyListView;
  public GameObject LevelsListView;
  public GameObject levelsScrollView;
  public string difficulty;

  private int STARS_TO_UNLOCK_MEDIUM = 150;
  private int STARS_TO_UNLOCK_HARD = 375;
  private int STARS_TO_UNLOCK_MASTER = 600;
  private int STARS_TO_UNLOCK_IMPOSSIBLE = 900;

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

  private void setLevelListItemCount() {
    int levels = 75;
    if (difficulty == "impossible") {
      levels = 33;
    }
    levelsScrollView.GetComponent<Mosframe.DynamicVScrollView>().totalItemCount = levels;
  }

  public void onDifficultyClick(string difficulty) {

    if (difficulty == "medium" && GameManager.totalStars < STARS_TO_UNLOCK_MEDIUM) {
      return;
    } else if (difficulty == "hard" && GameManager.totalStars < STARS_TO_UNLOCK_HARD) {
      return;
    }

    LevelManager.difficulty = difficulty;
    GameManager.currentStars = getCurrentStars(difficulty);
    setLevelListItemCount();

    DifficultyListView.SetActive(false);
    LevelsListView.SetActive(true);
	}

  void Start() {
    if (difficulty == "medium" && GameManager.totalStars >= STARS_TO_UNLOCK_MEDIUM) {
      this.gameObject.transform.GetChild(2).gameObject.SetActive(false);
    } else if (difficulty == "hard" && GameManager.totalStars >= STARS_TO_UNLOCK_HARD) {
      this.gameObject.transform.GetChild(2).gameObject.SetActive(false);
    }
    
    if (GameManager.totalStars >= STARS_TO_UNLOCK_MASTER) {
      this.gameObject.transform.parent.gameObject.transform.GetChild(3).gameObject.SetActive(true);
    }
    if (GameManager.totalStars >= STARS_TO_UNLOCK_IMPOSSIBLE) {
      this.gameObject.transform.parent.gameObject.transform.GetChild(4).gameObject.SetActive(true);
    }
  }
}