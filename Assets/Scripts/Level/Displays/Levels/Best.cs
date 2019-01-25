using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Best : MonoBehaviour {
  void Start() {
    if (GameManager.gameType == "ranked") {
      Destroy(this.gameObject.transform.parent.gameObject);
    } else if (GameManager.gameType == "levels") {
      GameManager.loadLevelCurrentBest();
    } else if (GameManager.gameType == "time_trials") {
      GameManager.loadTimeTrialsCurrentBest(LevelManager.difficulty);
    }
    this.gameObject.GetComponent<TextMeshProUGUI>().text = GameManager.currentBest.ToString();
  }
}
