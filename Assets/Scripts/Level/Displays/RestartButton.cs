using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour {
  public void onRestartClick() {
    LevelManager.time = 0;
    GameManager.Load("Game");
  }
}
