using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;
using System.IO;


public static class MovingObject {
  private static bool isMoving = false;
  private static GameObject obj;
  private static Vector3 position;
  private static Swipe swipeDirection;

  public static bool getIsMoving() {
	  return isMoving;
  }
  public static void setIsMoving(bool moving) {
	  isMoving = moving;
  }

  public static GameObject getObject() {
	  return obj;
  }
  public static void setObject(GameObject gameObject) {
	  obj = gameObject;
  }

  public static Vector3 getPosition() {
	  return position;
  }
  public static void setPosition(Vector3 pos) {
	  position = pos;
  }

  public static Swipe getSwipeDirection() {
	  return swipeDirection;
  }
  public static void setSwipeDirection(Swipe dir) {
	  swipeDirection = dir;
  }
}
