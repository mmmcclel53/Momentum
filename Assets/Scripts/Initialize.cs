using System.Collections;
using System.Collections.Generic;
using System.IO;
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
  }

	void Start () {
    loadPlayerRank();
    loadPlayerStars();
  }	
}
