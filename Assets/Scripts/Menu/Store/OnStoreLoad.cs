using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OnStoreLoad : MonoBehaviour {

  void Start () {
    GameManager.updateShipUnlocks();
		for (int i=1; i<12; i++) {
      if (GameManager.shipUnlocks[i]) {
        this.gameObject.transform.GetChild(i).gameObject.transform.GetChild(0).gameObject.SetActive(true);
        this.gameObject.transform.GetChild(i).gameObject.transform.GetChild(1).gameObject.SetActive(false);
      }
    }
	}
  
}
