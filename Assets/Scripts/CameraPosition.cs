using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour {
  
  private const float cameraClippingPlane = 35000;

  private const float HEIGHT_INCREMENT = 25;
  private const float DEFAULT_HEIGHT = 100;

  private const float WIDTH_INCREMENT = 1000;
  private const float DEFAULT_WIDTH = 3230;

  private Vector3 calculatePosition(float height, float fWidth) {
    float fT = fWidth / Screen.width * Screen.height;
    fT = fT / (2.0f * Mathf.Tan (0.5f * Camera.main.fieldOfView * Mathf.Deg2Rad));
    Vector3 v3T = Camera.main.transform.position;
    v3T.y = height;
    v3T.z = -fT;
    return v3T;
  }

  void Start() {
    int index = Array.IndexOf(LevelUtility.difficulties, LevelManager.difficulty);
    float height = DEFAULT_HEIGHT + (HEIGHT_INCREMENT*index);
    float width = DEFAULT_WIDTH + (WIDTH_INCREMENT*index);
    
    this.gameObject.transform.GetChild(0).transform.position = calculatePosition(height, width);
    
    float cameraZ = this.gameObject.transform.GetChild(0).transform.position.z;
    if (LevelManager.difficulty == "impossible") {
      height = -3500f;
    }
    
    this.gameObject.transform.GetChild(1).transform.position = new Vector3(0, height, cameraZ + (cameraClippingPlane -1000));
  }
 }