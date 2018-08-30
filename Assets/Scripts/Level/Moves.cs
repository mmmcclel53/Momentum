using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moves : MonoBehaviour {

  void Start() {
    LevelManager.moves = 0;
  }

  void Update() {
    this.gameObject.GetComponent<UnityEngine.UI.Text>().text = LevelManager.moves.ToString();
	}
}
