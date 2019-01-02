using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyHintsButton : MonoBehaviour {
	public void onHintClick(int hintsToAdd) {
    GameManager.playerHints += hintsToAdd;
    GameManager.savePlayerDetails();
  }
}
