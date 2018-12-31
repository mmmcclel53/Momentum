using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintsButton : MonoBehaviour {
	void Start () {
    RectTransform parentRect = this.gameObject.transform.GetChild(0).gameObject.GetComponent<RectTransform>();    
		Text textComponent = this.gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
    textComponent.text = "101";
    parentRect.sizeDelta = new Vector2(textComponent.preferredWidth, textComponent.preferredHeight) + new Vector2(5,5);
	}
}
