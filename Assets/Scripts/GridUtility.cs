using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public static class GridUtility {
  // This is dumb...
  public static Vector3 addOffset(Vector3 pos) {
    pos.x += 1.5f;
    pos.y += 1.5f;
    return pos;
  }

  public static int calculateX(int tile) {
    return tile % 16;
  }

  public static int calculateY(int tile) {
    return -1 * Convert.ToInt32(Math.Floor((double)(tile/16)));
  }
}
