using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;
using System.IO;

public class OnGridLoad : MonoBehaviour {
  public Tilemap northTilemap;
  public Tilemap eastTilemap;
  public Tilemap southTilemap;
  public Tilemap westTilemap;

  private bool hasWall(int tile, int wall) {
    return (tile & wall) != 0;
  }

  // Use this for initialization
  void Start () {
    string difficulty = GameManager.getParam("difficulty");
    string path = "Assets/Resources/beginner.txt";
    // string path = "Assets/Resources/" + difficulty + ".txt";

    // Read the tiles directly from the difficulty file
    StreamReader reader = new StreamReader(path);
    string[] separators = {" "};
    string[] tiles = reader.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
    reader.Close();

    // Set tiles
    int x = 0; int y = 0;
    foreach (string tileString in tiles) {

      // Start next row
      if (x >= 16) {
        x = 0;
        y--;
      }

      int tile = Int32.Parse(tileString) % 16;
      if (tile == 0) {
        x++;
        continue;
      }

      // These should be children of their respective tilemap
      Tile northWall = Resources.Load <Tile> ("Tiles/NorthWall");
      Tile eastWall = Resources.Load <Tile> ("Tiles/EastWall");
      Tile southWall = Resources.Load <Tile> ("Tiles/SouthWall");
      Tile westWall = Resources.Load <Tile> ("Tiles/WestWall");
      if (hasWall(tile, 1)) {
        northTilemap.SetTile(new Vector3Int(x, y, 0), northWall);
      }
      if (hasWall(tile, 2)) {
        eastTilemap.SetTile(new Vector3Int(x, y, 0), eastWall);
      }
      if (hasWall(tile, 4)) {
        southTilemap.SetTile(new Vector3Int(x, y, 0), southWall);
      }
      if (hasWall(tile, 8)) {
        westTilemap.SetTile(new Vector3Int(x, y, 0), westWall);
      }
      x++;
    }       
  }
}
