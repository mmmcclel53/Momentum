using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsButton : MonoBehaviour {
  public void onLevelsClick() {
    GameManager.gameType = "puzzles";
  }
}
