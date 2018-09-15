using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CurrentScore : MonoBehaviour {	
  void Start() {
    if (GameManager.gameType == "ranked") {
      Destroy(this.gameObject.transform.parent.gameObject);
      return;
    }

    int level = LevelUtility.calculateIndex(LevelManager.level);
    for (int i=0; i<GameManager.currentStars[level-1]; i++) {
      this.gameObject.transform.GetChild(i).gameObject.SetActive(true);
    }
  }
}
