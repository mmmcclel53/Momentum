using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour {

  public Toggle musicToggle;
  public Toggle gameToggle;
  public Slider gridSlider;

	void Start() {
    musicToggle.isOn = GameManager.isMusicSoundsOn;
    gameToggle.isOn = GameManager.isGameSoundsOn;
		gridSlider.value = GameManager.gridVisibility;
	}

	void OnDisable() {
    GameManager.saveSettings();
  }
}
