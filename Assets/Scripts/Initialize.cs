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
    
    GameManager.easyStars = new int[] { 3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,2 };
    GameManager.mediumStars = new int[] { 3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3 };
    GameManager.hardStars = new int[] { 3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,2 };
    GameManager.masterStars = new int[] { 3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3 };
    GameManager.impossibleStars = new int[] { 3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3 };
    GameManager.playerExperience = 3500;

    GameManager.totalStars = GameManager.easyStars.Sum() + GameManager.mediumStars.Sum() + GameManager.hardStars.Sum() + GameManager.masterStars.Sum() + GameManager.impossibleStars.Sum();
  }

	void Start () {
    loadPlayerRank();
    loadPlayerStars();
  }	
}
