using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class OnTimeTrialEnd : MonoBehaviour {

  public GameObject completedText;
  public GameObject highScoreText;

  void Start() {

    LevelManager.time = 0;
    int completed = LevelManager.currentSolved;
    int best = GameManager.currentBest;
    string difficulty = LevelManager.difficulty;
    int[] levelsToUnlockReward = GameManager.timeTrialsLevelsToUnlockReward;

    // Hint Rewards
    if (difficulty == "easy") {
      if (best < levelsToUnlockReward[0] && completed >= levelsToUnlockReward[0]) {
        GameManager.playerHints += 5;
      }
      if (best < levelsToUnlockReward[1] && completed >= levelsToUnlockReward[1]) {
        GameManager.playerHints += 10;
      }
    } else if (difficulty == "medium" ) {
      if (best < levelsToUnlockReward[2] && completed >= levelsToUnlockReward[2]) {
        GameManager.playerHints += 15;
      }
      if (best < levelsToUnlockReward[3] && completed >= levelsToUnlockReward[3]) {
        GameManager.playerHints += 25;
      }
    } else if (difficulty == "hard") {
      if (best < levelsToUnlockReward[4] && completed >= levelsToUnlockReward[4]) {
        GameManager.playerHints += 35;
      }
      if (best < levelsToUnlockReward[5] && completed >= levelsToUnlockReward[5]) {
        GameManager.playerHints += 50;
      }
    }

    if (completed > best) {
      best = completed;
      GameManager.currentBest = best;
      GameManager.saveTimeTrialsBest(best, difficulty);
      GameManager.savePlayerDetails();
    }

    completedText.GetComponent<TextMeshProUGUI>().text = completed.ToString();
    highScoreText.GetComponent<TextMeshProUGUI>().text = best.ToString();
  }
}
