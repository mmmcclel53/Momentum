using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Initialize : MonoBehaviour {

  private void loadPlayerDetails() {
    // Load if file exists, otherwise create it
    try {
      GameManager.loadPlayerDetails();
    } catch {
      GameManager.savePlayerDetails();
    }
  }

  private void loadRankedScore() {
    // Load if file exists, otherwise create it
    try {
      GameManager.loadRankedScore();
    } catch {
      GameManager.saveRankedScore();
    }
  }

  private void loadPlayerStars() {
    GameManager.loadStars();
    GameManager.totalStars = GameManager.easyStars.Sum() + GameManager.mediumStars.Sum() + GameManager.hardStars.Sum() + GameManager.masterStars.Sum() + GameManager.impossibleStars.Sum();
  }

  private void loadTimeTrialScores() {
    GameManager.timeTrialsEasy = GameManager.loadTimeTrialsCurrentBest("easy");
    GameManager.timeTrialsMedium = GameManager.loadTimeTrialsCurrentBest("medium");
    GameManager.timeTrialsHard = GameManager.loadTimeTrialsCurrentBest("hard");
  }

  private void loadSettings() {
    // Load if file exists, otherwise create it
    try {
      GameManager.loadSettings();
    } catch {
      GameManager.saveSettings();
    }
  }

	void Start() {
    loadPlayerDetails();
    loadRankedScore();
    loadPlayerStars();
    loadTimeTrialScores();
    loadSettings();
  }	
}
