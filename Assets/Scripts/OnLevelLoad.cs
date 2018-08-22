using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;
using System.IO;

public class OnLevelLoad : MonoBehaviour {
  
  private GameManager GameManager;

  public Tilemap playersAndGoalTilemap;
  public Tilemap northTilemap;
  public Tilemap eastTilemap;
  public Tilemap southTilemap;
  public Tilemap westTilemap;

  private int calculateX(int tile) {
    return tile % 16;
  }

  private int calculateY(int tile) {
    return -1 * Convert.ToInt32(Math.Floor((double)(tile/16)));
  }

  private bool hasWall(int tile, int wall) {
    return (tile & wall) != 0;
  }

  private void setPlayersAndGoal(string[] movableTileStrings, string goalString) {
    
    // These should be children of the PlayersAndGoal tilemap
    Tile ship = Resources.Load <Tile> ("Tiles/Ship");
    Tile asteroid = Resources.Load <Tile> ("Tiles/Asteroid");
    Tile goal = Resources.Load <Tile> ("Tiles/Goal");

    for (int i=0; i<movableTileStrings.Length; i++) {
      int movableTile = Int32.Parse(movableTileStrings[i]);
      playersAndGoalTilemap.SetTile(new Vector3Int(calculateX(movableTile), calculateY(movableTile), 0), i == 0 ? ship : asteroid);
    }
    int goalTile = Int32.Parse(goalString);
    playersAndGoalTilemap.SetTile(new Vector3Int(calculateX(goalTile), calculateY(goalTile), 0), goal);
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

  // Use this for initialization
  void Start () {
    // string difficulty = GameManager.getParam("difficulty");
    string path = "Assets/Resources/beginner.txt";
    // string path = "Assets/Resources/" + difficulty + ".txt";

    // Read the tiles directly from the difficulty file
    StreamReader reader = new StreamReader(path);
    string[] separators = {" "};
    string[] tiles = reader.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
    string[] players = reader.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
    string goal = reader.ReadLine();
    // GameManager.SOLUTION = reader.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
    // GameManager.COMPLEXITY = Int32.Parse(reader.ReadLine());

    reader.Close();

    setTiles(tiles);
    setPlayersAndGoal(players, goal);
  }
}
