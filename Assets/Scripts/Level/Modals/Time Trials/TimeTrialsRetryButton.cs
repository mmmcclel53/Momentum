using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeTrialsRetryButton : MonoBehaviour {
  public void onRetryClick() {
    GameManager.Load("Game");
  }
}
