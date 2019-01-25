using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Moves : MonoBehaviour {

  void Start() {
    if (GameManager.gameType == "time_trials") {
      Destroy(this.gameObject.transform.parent.gameObject);
    }
    LevelManager.moves = 0;
  }

  void Update() {
    this.gameObject.GetComponent<TextMeshProUGUI>().text = LevelManager.moves.ToString();
	}
}
