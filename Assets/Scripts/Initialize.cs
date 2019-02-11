using CloudOnce;
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
    Achievements.MeteorMazeWelcome.Unlock();

    loadPlayerDetails();
    loadRankedScore();
    loadPlayerStars();
    loadTimeTrialScores();
    loadSettings();

    GameManager.updateUnlocks();

    // Achievements & Leaderboards
    if (
      GameManager.totalStars >= 600 && GameManager.bestRankedExperience >= 5000 &&
      GameManager.timeTrialsEasy >= 15 &&
      GameManager.timeTrialsMedium >= 10 &&
      GameManager.timeTrialsHard >= 5 &&
      (GameManager.timeTrialsEasy + GameManager.timeTrialsMedium + GameManager.timeTrialsHard) >= 30
    ) {
      Achievements.Completionist.Unlock();
    }
  }	
}
