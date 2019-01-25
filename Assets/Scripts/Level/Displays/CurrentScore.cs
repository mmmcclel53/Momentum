using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CurrentScore : MonoBehaviour {	
  void Start() {
    if (GameManager.gameType == "ranked" || GameManager.gameType == "levels") {
      Destroy(this.gameObject.transform.parent.gameObject);
      return;
    }
  }

  void Update() {
    this.gameObject.GetComponent<TextMeshProUGUI>().text = LevelManager.currentSolved.ToString();
	}
}
