using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OnRewardUnlocksLoad : MonoBehaviour {
  void Start() {
    GameManager.updateUnlocks();
		for (int i=0; i<6; i++) {
      if (GameManager.rewardUnlocks[i]) {
        this.gameObject.transform.GetChild(i).gameObject.transform.GetChild(1).gameObject.SetActive(false);
        this.gameObject.transform.GetChild(i).gameObject.transform.GetChild(2).gameObject.SetActive(true);
      }
    }
	}
}
