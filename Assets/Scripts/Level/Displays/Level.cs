using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Level : MonoBehaviour {
  void Start() {
    if (GameManager.gameType == "ranked") {
      this.gameObject.GetComponent<TextMeshProUGUI>().text = "Ranked";
    } else if (GameManager.gameType == "time_trials") {
      this.gameObject.GetComponent<TextMeshProUGUI>().text = "Time Trials";
    } else {
      this.gameObject.GetComponent<TextMeshProUGUI>().text = ("Level " + LevelUtility.calculateIndex(LevelManager.level)).ToString();
    }
  }
}
