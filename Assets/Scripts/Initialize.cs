using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Initialize : MonoBehaviour {

  private void loadPlayerRank() {
    // Load if file exists, otherwise create it
    try {
      GameManager.loadPlayerDetails();
    } catch {
      GameManager.playerExperience = 0;
      GameManager.playerRank = "Novice";
      GameManager.savePlayerDetails();
    }
  }

  private void loadPlayerStars() {
    GameManager.loadStars();
    GameManager.totalStars = GameManager.easyStars.Sum() + GameManager.mediumStars.Sum() + GameManager.hardStars.Sum() + GameManager.masterStars.Sum() + GameManager.impossibleStars.Sum();
  }

	void Start() {
    loadPlayerRank();
    loadPlayerStars();
  }	
}
