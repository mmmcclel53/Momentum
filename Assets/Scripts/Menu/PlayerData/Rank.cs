using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Rank : MonoBehaviour {
	void Update() {
    Sprite icon = Resources.Load <Sprite> (("Ranks/" + GameManager.rankedTitle).ToString());
    this.gameObject.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = icon;
    this.gameObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = GameManager.rankedTitle;
	}
}
