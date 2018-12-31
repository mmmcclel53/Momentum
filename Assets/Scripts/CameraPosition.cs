using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour {
  
  private const float INCREMENT = 1000;
  private const float DEFAULT_POSITION = 3150;

  private Vector3 calculatePosition(float fWidth) {
    float fT = fWidth / Screen.width * Screen.height;
    fT = fT / (2.0f * Mathf.Tan (0.5f * Camera.main.fieldOfView * Mathf.Deg2Rad));
    Vector3 v3T = Camera.main.transform.position;
    v3T.z = -fT;
    return v3T;
  }

  void Start () {
    int index = Array.IndexOf(LevelUtility.difficulties, LevelManager.difficulty);
    float width = DEFAULT_POSITION + (INCREMENT*index);
    
    this.gameObject.transform.GetChild(0).transform.position = calculatePosition(width);
    this.gameObject.transform.GetChild(1).transform.position = calculatePosition(width-8000);
  }
 }