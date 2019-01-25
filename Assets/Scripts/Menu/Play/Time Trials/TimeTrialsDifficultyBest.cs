using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TimeTrialsDifficultyBest : MonoBehaviour {

  public string difficulty;

	// Use this for initialization
	void Start() {
    int best = 0;
		switch (difficulty) {
      case "easy":
        best = GameManager.timeTrialsEasy;
        break;
      case "medium":
        best = GameManager.timeTrialsMedium;
        break;
      case "hard":
        best = GameManager.timeTrialsHard;
        break;
    }
    this.gameObject.GetComponent<Text>().text = ("Best:   " + best).ToString();
	}
}
