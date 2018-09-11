﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour {

  public float time = LevelManager.time;
	
  void Start() {
    time = LevelManager.time;
    LevelManager.paused = false;
  }

	// Update is called once per frame
	void Update() {
    if (LevelManager.paused) {
      return;
    }
    
    time += Time.deltaTime;
    int minutes = Mathf.FloorToInt(time / 60F);
    int seconds = Mathf.FloorToInt(time - minutes * 60);
    this.gameObject.GetComponent<Text>().text = string.Format("{0:0}:{1:00}", minutes, seconds);
    LevelManager.time = time;
	}
}