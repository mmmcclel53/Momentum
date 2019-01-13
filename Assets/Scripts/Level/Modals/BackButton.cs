using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour {

  private const int rankedPenalty = -15;
  public GameObject rankedPenaltyWarningScreen;

  void OnDisable() {
    if (GameManager.gameType == "ranked" && !LevelManager.solved) {
      GameManager.adjustPlayerExperience(rankedPenalty);
      GameManager.savePlayerDetails();
    }
  }

  public void onBackButton() {
    if (GameManager.gameType == "ranked") {
      LevelManager.paused = true;
      rankedPenaltyWarningScreen.SetActive(true);
    } else {
      GameManager.Load("MainMenu");
    }
  }
}
