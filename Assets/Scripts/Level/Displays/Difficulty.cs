using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour {
  void Start() {
    TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
    this.gameObject.GetComponent<Text>().text = textInfo.ToTitleCase(GameManager.difficulty);
  }
}
