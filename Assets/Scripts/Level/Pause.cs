using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

  public GameObject puzzlePauseModal;
  public GameObject rankedPauseModal;

  private void setModalVisibility(GameObject obj) {
    if (LevelManager.paused) {
      obj.SetActive(true);
    } else {
      obj.SetActive(false);
    }
  }

  // Should probably change this 
	public void togglePause() {
    LevelManager.paused = !LevelManager.paused;
    if (GameManager.gameType == "ranked") {
      setModalVisibility(rankedPauseModal);
    } else {
      setModalVisibility(puzzlePauseModal);
    }
  }
}
