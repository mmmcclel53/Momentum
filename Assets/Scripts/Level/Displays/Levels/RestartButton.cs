using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour {
  public void onRestartClick() {
    GameManager.Load("Game");
  }

  void Start() {
    if (GameManager.gameType == "ranked" || GameManager.gameType == "time_trials") {
      Destroy(this.gameObject);
    }
  }
}
