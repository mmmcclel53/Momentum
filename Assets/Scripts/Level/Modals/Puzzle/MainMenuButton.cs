using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButton : MonoBehaviour {
  public void onMainMenuClick() {
    GameManager.Load("MainMenu");
  }
}
