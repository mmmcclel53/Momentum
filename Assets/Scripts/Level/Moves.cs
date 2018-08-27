using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moves : MonoBehaviour {
	
  void Start() {
    GameManager.setParam("moves", "0");
  }

  void Update() {
    this.gameObject.GetComponent<UnityEngine.UI.Text>().text = GameManager.getParam("moves");
	}
}
