using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour {
	public void onSelectClick() {
    string ship = this.gameObject.transform.parent.GetChild(1).gameObject.transform.GetChild(0).GetComponent<Image>().sprite.name;
    GameManager.playerShip = ship;
    GameManager.savePlayerDetails();
  }
}
