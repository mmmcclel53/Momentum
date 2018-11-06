﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class OnLevelLoad : MonoBehaviour {
  
  public GameObject[] movableObjects;  
  public GameObject goalObj;

  public Tilemap playersAndGoal;
  public Tilemap northTilemap;
  public Tilemap eastTilemap;
  public Tilemap southTilemap;
  public Tilemap westTilemap;

  private bool hasWall(int tile, int wall) {
    return (tile & wall) != 0;
  }

  // Set both tile and real object positions
  private void setPlayersAndGoal(string[] movableTileStrings, string goalString) {
    Tile ship = Resources.Load <Tile> ("Tiles/Ship");
    Tile asteroid = Resources.Load <Tile> ("Tiles/Asteroid");
    Tile goal = Resources.Load <Tile> ("Tiles/Goal");

    for (int i=0; i<movableTileStrings.Length; i++) {
      int movableTile = Int32.Parse(movableTileStrings[i]);
      movableObjects[i].transform.position = northTilemap.CellToWorld(new Vector3Int(LevelUtility.calculateX(movableTile), LevelUtility.calculateY(movableTile), 0));
      playersAndGoal.SetTile(new Vector3Int(LevelUtility.calculateX(movableTile), LevelUtility.calculateY(movableTile), 0), i == 0 ? ship : asteroid);
    }
    int goalTile = Int32.Parse(goalString);
    goalObj.transform.position = northTilemap.CellToWorld(new Vector3Int(LevelUtility.calculateX(goalTile), LevelUtility.calculateY(goalTile), 0));
    playersAndGoal.SetTile(new Vector3Int(LevelUtility.calculateX(goalTile), LevelUtility.calculateY(goalTile), 0), goal);
  }

  private void setTiles(string[] tiles) {
    
    // These should be children of their respective tilemap
    Tile northWall = Resources.Load <Tile> ("Tiles/NorthWall");
    Tile eastWall = Resources.Load <Tile> ("Tiles/EastWall");
    Tile southWall = Resources.Load <Tile> ("Tiles/SouthWall");
    Tile westWall = Resources.Load <Tile> ("Tiles/WestWall");

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

  private TextAsset getPath() {
    if (GameManager.gameType == "puzzles") {
      return (TextAsset)Resources.Load("Levels/Puzzles/" + LevelManager.difficulty + "/" + LevelManager.difficulty + LevelManager.level, typeof(TextAsset));
    }

    return (TextAsset)Resources.Load("Levels/Ranked/easy0_1", typeof(TextAsset)); //+ LevelUtility.calculateRankedDifficulty() + LevelUtility.calculateRankedLevel(), typeof(TextAsset));
  }

  // Use this for initialization
  void Start() {

    // Disable screen capture (you filthy cheaters!)
    // getWindow().setFlags(LayoutParams.FLAG_SECURE, LayoutParams.FLAG_SECURE);

    TextAsset file = getPath();
    // TextAsset file =  (TextAsset)Resources.Load("Levels/Puzzles/easy/easy0_1", typeof(TextAsset));

    // Read the tiles directly from the difficulty file
    string[] separators = {" "};
    string[] newLineSeparators = new string[] { "\r\n", "\r", "\n" };    

    string[] lines = file.text.Split(newLineSeparators, StringSplitOptions.None);
    string[] tiles = lines[0].Split(separators, StringSplitOptions.RemoveEmptyEntries);
    string[] players = lines[1].Split(separators, StringSplitOptions.RemoveEmptyEntries);
    string goal = lines[2];
    LevelManager.solution = lines[3].Split(separators, StringSplitOptions.RemoveEmptyEntries);

    setTiles(tiles);
    setPlayersAndGoal(players, goal);
  }
}
