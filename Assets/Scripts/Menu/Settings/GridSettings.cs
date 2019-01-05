using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class GridSettings : MonoBehaviour {

  public Slider gridSlider;
  public Tilemap gridTilemap;
  public Tile grid;

  private void setGridLines(Tile grid) {
    // Reset
    for (int x=-3; x < 5; x++) {
      for (int y=-1; y > -9; y--) {
        gridTilemap.SetTile(new Vector3Int(x, y, 0), null);
      }
    }

    for (int x=-3; x < 5; x++) {
      for (int y=-1; y > -9; y--) {
        gridTilemap.SetTile(new Vector3Int(x, y, 0), grid);
      }
    }
  }

  public void onGridVisibilityChange() {
    GameManager.gridVisibility = gridSlider.value;
    Color color = grid.color;
    color.a = GameManager.gridVisibility;
    grid.color = color;
    setGridLines(grid);
  }

  void Start() {
    Color color = grid.color;
    color.a = GameManager.gridVisibility;
    grid.color = color;
    setGridLines(grid);
  }
}
