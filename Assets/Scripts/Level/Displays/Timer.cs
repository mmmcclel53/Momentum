using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Timer : MonoBehaviour {

  public GameObject timeTrialsSummaryModal;

  private float time = 0;

  void Start() {
    if (GameManager.gameType == "levels") {
      Destroy(this.gameObject.transform.parent.gameObject);
      return;
    }

    if (GameManager.gameType == "ranked") {
      time = 0;      
    } else if (GameManager.gameType == "time_trials") {
      time = LevelManager.time == 0 ? LevelUtility.getTimeTrialSecondsToComplete() + 1 : LevelManager.time;
    }
    
    LevelManager.paused = false;
  }

	// Update is called once per frame
	void Update() {
    if (LevelManager.solved || LevelManager.paused) {
      return;
    }

    if (GameManager.gameType == "ranked") {
      time += Time.deltaTime;
    } else if (GameManager.gameType == "time_trials") {
      if (time <= 1) {
        LevelManager.paused = true;
        timeTrialsSummaryModal.SetActive(true);
        return;
      }
      time -= Time.deltaTime;
    }

    int minutes = Mathf.FloorToInt(time / 60F);
    int seconds = Mathf.FloorToInt(time - minutes * 60);
    this.gameObject.GetComponent<TextMeshProUGUI>().text = string.Format("{0:0}:{1:00}", minutes, seconds);
    LevelManager.time = time;
	}
}
