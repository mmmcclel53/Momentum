using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyStarCount : MonoBehaviour {

  public string difficulty;

	// Use this for initialization
	void Start () {
    int count = 0;
    int total = 120;
		switch (difficulty) {
      case "easy":
        count = GameManager.easyStars.Sum();
        break;
      case "medium":
        count = GameManager.mediumStars.Sum();
        break;
      case "hard":
        count = GameManager.hardStars.Sum();
        break;
      case "master":
        count = GameManager.masterStars.Sum();
        break;
      case "impossible":
        count = GameManager.impossibleStars.Sum();
        break;
    }
    this.gameObject.GetComponent<Text>().text = (count + "/" + total).ToString();
	}
}
