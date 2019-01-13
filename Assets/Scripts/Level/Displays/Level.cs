using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour {
  void Start() {
    if (GameManager.gameType == "ranked") {
      this.gameObject.GetComponent<Text>().text = "Ranked";
    } else if (GameManager.gameType == "time_trials") {
      this.gameObject.GetComponent<Text>().text = "Time Trials";
    } else {
      this.gameObject.GetComponent<Text>().text = ("Level " + LevelUtility.calculateIndex(LevelManager.level)).ToString();
    }
  }
}
