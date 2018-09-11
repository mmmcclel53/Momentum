using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moves : MonoBehaviour {

  void Start() {
    LevelManager.moves = 0;
  }

  void Update() {
    this.gameObject.GetComponent<Text>().text = LevelManager.moves.ToString();
	}
}
