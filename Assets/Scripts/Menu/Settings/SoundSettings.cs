using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour {

	public void onMusicToggle() {
    GameManager.isMusicSoundsOn = !GameManager.isMusicSoundsOn;
    GameManager.saveSettings();
  }

  public void onGameToggle() {
    GameManager.isGameSoundsOn = !GameManager.isGameSoundsOn;    
    GameManager.saveSettings();
  }
  
}
