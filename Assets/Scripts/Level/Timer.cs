using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

  public float time = LevelManager.time;
	
  void Start() {
    time = LevelManager.time;
    LevelManager.pause = false;
  }

	// Update is called once per frame
	void Update() {
    if (!LevelManager.pause) {
      time += Time.deltaTime;
      int minutes = Mathf.FloorToInt(time / 60F);
      int seconds = Mathf.FloorToInt(time - minutes * 60);
      this.gameObject.GetComponent<UnityEngine.UI.Text>().text = string.Format("{0:0}:{1:00}", minutes, seconds);
      LevelManager.time = time;
    }
	}
}
