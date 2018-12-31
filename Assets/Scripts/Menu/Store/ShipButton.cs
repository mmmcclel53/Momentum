using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ShipButton : MonoBehaviour {

	public void onClick(int index) {
    // Absolute unit of garbage. Thanks Unity!
    GameObject shipInfo = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "ShipInfo").First();

    if (GameManager.shipUnlocks[index]) {
      shipInfo.transform.GetChild(1).gameObject.SetActive(true);
      shipInfo.transform.GetChild(2).gameObject.SetActive(false);
    } else {
      shipInfo.transform.GetChild(1).gameObject.SetActive(false);
      shipInfo.transform.GetChild(2).gameObject.SetActive(true);
      shipInfo.transform.GetChild(2).gameObject.GetComponent<Text>().text = ("Requirement:\n" + GameManager.shipUnlockReqs[index]).ToString();
    }

    GameObject shipImage = Instantiate(this.gameObject, shipInfo.transform);
    shipImage.GetComponent<RectTransform>().localScale = new Vector2(1f, 1f);
    shipImage.GetComponent<RectTransform>().anchorMin = new Vector2(0.5f, 0.6f);
    shipImage.GetComponent<RectTransform>().anchorMax = new Vector2(0.5f, 0.6f);
    shipImage.GetComponent<RectTransform>().sizeDelta = new Vector2(180f, 180f);
    shipImage.transform.position = new Vector3(0f, 5f, 0f);
    shipImage.transform.SetSiblingIndex(1);
    Destroy(shipImage.GetComponent<Button>());
  }

}
