using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (GameManager.gameType == "ranked" || GameManager.gameType == "time_trials") {
      Destroy(this.gameObject.transform.parent.gameObject);
      return;
    }

    int level = LevelUtility.calculateIndex(LevelManager.level);
    for (int i=0; i<GameManager.currentStars[level-1]; i++) {
      this.gameObject.transform.GetChild(i).gameObject.SetActive(true);
    }
	}
}
