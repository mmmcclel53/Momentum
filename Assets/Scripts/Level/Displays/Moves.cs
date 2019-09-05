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
    LevelManager.moves.Clear();
  }

  void Update() {
    this.gameObject.GetComponent<TextMeshProUGUI>().text = LevelManager.moves.Count.ToString();
	}
}
