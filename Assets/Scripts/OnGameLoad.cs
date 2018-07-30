using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;
using System.IO;

public class OnGameLoad : MonoBehaviour {
  public Tilemap tilemap;
  public Tile nwWall;
  public Tile neWall;
  public Tile swWall;
  public Tile seWall;
  public Tile northWall;
  public Tile eastWall;
  public Tile southWall;
  public Tile westWall;

  bool hasCornerWall(int tile, int wall1, int wall2) {
    return hasWall(tile, wall1) && hasWall(tile, wall2);
  }

  bool hasWall(int tile, int wall) {
    return (tile & wall) > 0;
  }

  // Use this for initialization
  void Start () {
    string difficulty = GameManager.getParam("difficulty");
    string path = "Assets/Resources/beginner.txt";
    // string path = "Assets/Resources/" + difficulty + ".txt";

    // Read the tiles directly from the difficulty file
    StreamReader reader = new StreamReader(path);
    string[] separators = {","};
    string[] tiles = reader.ReadToEnd().Split(separators, StringSplitOptions.RemoveEmptyEntries);
    reader.Close();

    int x = -1; int y = 0;
    foreach (string tile in tiles) {
      int tileInt = Int32.Parse(tile);
      x++;

      // Start next row
      if (x >= 16) {
        x = 0;
        y--;
      }
      Debug.Log(x.ToString() + ' ' + y.ToString());

      // Corners
      if (hasCornerWall(tileInt, 1, 8)) {
        tilemap.SetTile(new Vector3Int(x, y, 0), nwWall);
        continue;
      }
      if (hasCornerWall(tileInt, 1, 2)) {
        tilemap.SetTile(new Vector3Int(x, y, 0), neWall);
        continue;
      }
      if (hasCornerWall(tileInt, 2, 4)) {
        tilemap.SetTile(new Vector3Int(x, y, 0), seWall);
        continue;
      }
      if (hasCornerWall(tileInt, 4, 8)) {
        tilemap.SetTile(new Vector3Int(x, y, 0), swWall);
        continue;
      }

      // Walls
      if (hasWall(tileInt, 1)) {
        tilemap.SetTile(new Vector3Int(x, y, 0), northWall);
        continue;
      }
      if (hasWall(tileInt, 2)) {
        tilemap.SetTile(new Vector3Int(x, y, 0), eastWall);
        continue;
      }
      if (hasWall(tileInt, 4)) {
        tilemap.SetTile(new Vector3Int(x, y, 0), southWall);
        continue;
      }
      if (hasWall(tileInt, 8)) {
        tilemap.SetTile(new Vector3Int(x, y, 0), westWall);
        continue;
      }
    }       
  }
}
