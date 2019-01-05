using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour {
  public void onPlayClick() {
    GameManager.gameType = "ranked";
    LevelManager.difficulty = LevelUtility.calculateRankedDifficulty();
    LevelManager.level = LevelUtility.calculateRankedLevel();
    GameManager.Load("Game");
  }
}
