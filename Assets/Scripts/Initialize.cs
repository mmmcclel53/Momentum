using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Initialize : MonoBehaviour {

  private void loadSettings() {
    // Load if file exists, otherwise create it
    try {
      GameManager.loadSettings();
    } catch {
      GameManager.saveSettings();
    }
  }

  private void loadPlayerRank() {
    // Load if file exists, otherwise create it
    try {
      GameManager.loadPlayerDetails();
    } catch {
      GameManager.savePlayerDetails();
    }
  }

  private void loadPlayerStars() {
    GameManager.loadStars();
    GameManager.totalStars = GameManager.easyStars.Sum() + GameManager.mediumStars.Sum() + GameManager.hardStars.Sum() + GameManager.masterStars.Sum() + GameManager.impossibleStars.Sum();
  }

	void Start() {
    loadSettings();
    loadPlayerRank();
    loadPlayerStars();
  }	
}
