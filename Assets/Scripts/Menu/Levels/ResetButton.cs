using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ResetButton : MonoBehaviour {
  public void onResetClick() {
    GameManager.Load(SceneManager.GetActiveScene().name);
  }
}
