using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using DG.Tweening;

public class GridManager : MonoBehaviour
{
    #region Variables
    int count;
    private Cell[,] gridElements;
    #endregion

    private static readonly Vector2Int[] Indexes =
    {
        new Vector2Int(1, 0),
        new Vector2Int(0, 1),
        new Vector2Int(-1, 0),
        new Vector2Int(0, -1)
    };

    #region Singleton
    public static GridManager instance = null;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    public void GenerateGrid(int gridCount)
    {
        count = gridCount;
        gridElements = new Cell[gridCount, gridCount];
        CameraManager.instance.SetCamPos(gridCount);

        int x = 0 - gridCount / 2;
        int y = 0 - gridCount / 2;

        for (int i = 0; i < gridCount; i++)
        {
            for (int j = 0; j < gridCount; j++)
            {
                GameObject cell = Instantiate(Resources.Load<GameObject>("cell"), new Vector2(x, y), Quaternion.identity, transform);
                cell.transform.DOScale(Vector3.one * 0.75f, 0.25f);

                gridElements[j, i] = cell.GetComponent<Cell>();
                cell.GetComponent<Cell>().x = j;
                cell.GetComponent<Cell>().y = i;
                x++;
            }
            x = 0 - gridCount / 2;
            y++;
        }
    }

    public List<Cell> ControlNeighborCells(int x, int y, List<Cell> addedNeighbors=null)
    {
        if (addedNeighbors == null) addedNeighbors = new List<Cell>();

        foreach (var index in Indexes)
        {
            if (x + index.x >= count || y + index.y >= count || x + index.x < 0 || y + index.y < 0) continue;

            Cell neighbor = gridElements[x + index.x, y + index.y];

            if (!neighbor.isChildEnable || neighbor == null || addedNeighbors.Contains(neighbor)) continue;

            addedNeighbors.Add(neighbor);
            ControlNeighborCells(neighbor.x, neighbor.y, addedNeighbors);
        }
        return addedNeighbors;
    }
}
