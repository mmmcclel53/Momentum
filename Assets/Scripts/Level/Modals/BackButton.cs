using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour {

  public GameObject rankedPenaltyWarningScreen;
  // private const int rankedPenalty = -15;

  // void OnDisable() {
  //   if (GameManager.gameType == "ranked" && !LevelManager.solved) {
  //     GameManager.adjustRankedExperience(rankedPenalty);
  //     GameManager.saveRankedScore();
  //   }
  // }

  public void onBackButton() {
    LevelManager.time = 0;
    if (GameManager.gameType == "ranked") {
      LevelManager.paused = true;
      rankedPenaltyWarningScreen.SetActive(true);
    } else {
      GameManager.Load("MainMenu");
    }
  }
}
