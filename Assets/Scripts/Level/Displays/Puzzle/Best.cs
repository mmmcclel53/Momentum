using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Best : MonoBehaviour {
  void Start() {
    if (GameManager.gameType == "ranked") {
      Destroy(this.gameObject.transform.parent.gameObject);
      return;
    }
    this.gameObject.GetComponent<Text>().text = GameManager.currentBest.ToString();
  }
}
