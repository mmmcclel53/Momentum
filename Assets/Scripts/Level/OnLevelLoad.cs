using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

public class OnLevelLoad : MonoBehaviour {
  
  public GameObject[] movableObjects;  
  public GameObject goalObj;
  public GameObject shipObj;

  public GameObject puzzleSolvedModal;
  public GameObject rankedSolvedModal;

  public Tilemap playersAndGoal;
  public Tilemap northTilemap;
  public Tilemap eastTilemap;
  public Tilemap southTilemap;
  public Tilemap westTilemap;
  public Tilemap gridTilemap;

  private Tile ship;
  private Tile asteroid;
  private Tile goal;

  private static int calculateX(int tile) {
    return tile % LevelUtility.calculateBoardSize();
  }

  private static int calculateY(int tile) {
    return -1 * Convert.ToInt32(Math.Floor((double)(tile / LevelUtility.calculateBoardSize())));
  }

  private bool hasWall(int tile, int wall) {
    return (tile & wall) != 0;
  }

  private bool isCurrentShipObj() {
    return MovingObject.getObject() == shipObj;
  }

  private void setGrid(int increment) {
    float x = this.gameObject.transform.position.x;
    float y = this.gameObject.transform.position.y;
    
    int index = Array.IndexOf(LevelUtility.difficulties, LevelManager.difficulty);
    x += -increment*index;
    y += increment*index;

		this.gameObject.transform.position = new Vector2(x, y);
  }

  // Set both tile and real object positions
  private void setPlayersAndGoal(string[] movableTileStrings, string goalString) {
    ship = Resources.Load <Tile> ("Tiles/Ship");
    asteroid = Resources.Load <Tile> ("Tiles/Asteroid");
    goal = Resources.Load <Tile> ("Tiles/Goal");

    for (int i=0; i<movableTileStrings.Length; i++) {
      int movableInt = Int32.Parse(movableTileStrings[i]);
      Vector3Int movableTile = new Vector3Int(calculateX(movableInt), calculateY(movableInt), 0);
      movableObjects[i].SetActive(true);
      movableObjects[i].transform.position = northTilemap.CellToWorld(movableTile);
      playersAndGoal.SetTile(movableTile, i == 0 ? ship : asteroid);
    }
    int goalInt = Int32.Parse(goalString);
    Vector3Int goalTile = new Vector3Int(calculateX(goalInt), calculateY(goalInt), 0);
    goalObj.transform.position = northTilemap.CellToWorld(goalTile);
    playersAndGoal.SetTile(goalTile, goal);

    LevelManager.goalTile = goalTile;
  }

  private void setTiles(string[] tiles) {
    
    // These should be children of their respective tilemap
    Tile northWall = Resources.Load <Tile> ("Tiles/NorthWall");
    Tile eastWall = Resources.Load <Tile> ("Tiles/EastWall");
    Tile southWall = Resources.Load <Tile> ("Tiles/SouthWall");
    Tile westWall = Resources.Load <Tile> ("Tiles/WestWall");
    
    // Set Grid Visibility from Settings
    Tile grid = Resources.Load <Tile> ("Tiles/Grid");
    Color color = grid.color;
    color.a = GameManager.gridVisibility;
    grid.color = color;

    int boardSize = LevelUtility.calculateBoardSize();
    int middleSquare = boardSize / 2;
    int x = 0; int y = 0;
    foreach (string tileString in tiles) {

      // Start next row
      if (x >= boardSize) {
        x = 0;
        y--;
      }

      // Set all but middle grid squares (ignore for Easy difficulty)
      if (
        LevelManager.difficulty == "easy" ||
        ((x != middleSquare && x != middleSquare-1) || (Math.Abs(y) != middleSquare && Math.Abs(y) != middleSquare-1))
      ) {
        gridTilemap.SetTile(new Vector3Int(x, y, 0), grid);
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

    return (TextAsset)Resources.Load("Levels/Ranked/" + LevelManager.difficulty + LevelManager.level, typeof(TextAsset));
  }

  void Start() {
    TextAsset file = getPath();

    // Read the tiles directly from the difficulty file
    string[] separators = {" "};
    string[] newLineSeparators = new string[] { "\r\n", "\r", "\n" };    

    string[] lines = file.text.Split(newLineSeparators, StringSplitOptions.None);
    string[] tiles = lines[0].Split(separators, StringSplitOptions.RemoveEmptyEntries);
    string[] players = lines[1].Split(separators, StringSplitOptions.RemoveEmptyEntries);
    string goal = lines[2];

    LevelManager.solution = lines[3].Split(separators, StringSplitOptions.RemoveEmptyEntries);
    LevelManager.solved = false;

    setGrid(500);
    setTiles(tiles);
    setPlayersAndGoal(players, goal);
    GameManager.loadCurrentBest();
  }

  // Win condition 
  void Update() {
    GameObject movingObj = MovingObject.getObject();
    if (LevelManager.solved || movingObj == null) {
      return;
    }

    Vector3 newPos = MovingObject.getPosition();
    if (movingObj.transform.position == newPos) {
      Vector3Int tilePos = playersAndGoal.WorldToCell(newPos);

      if (isCurrentShipObj() && playersAndGoal.GetTile(tilePos) == goal) {
        LevelManager.solved = true;
        if (GameManager.gameType == "ranked") {
          rankedSolvedModal.SetActive(true);
        } else {
          puzzleSolvedModal.SetActive(true);
        }
      }
      playersAndGoal.SetTile(tilePos, isCurrentShipObj() ? ship : asteroid);
      MovingObject.setIsMoving(false);
    }
    movingObj.transform.position = Vector3.MoveTowards(movingObj.transform.position, newPos, 10000 * Time.deltaTime);
  }
}
