using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using DG.Tweening;

public class GridManager : MonoBehaviour
{
    #region Variables
    int gridCount;
    #endregion

    #region Singleton
    public static GridManager instance = null;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    public void GenerateGrid()
    {
        gridCount = UIManager.instance.gridCount;

        CameraManager.instance.SetCamPos(gridCount);

        int x = 0 - gridCount / 2;
        int y = 0 + gridCount / 2;

        for (int i = 0; i < gridCount; i++)
        {
            for (int j = 0; j < gridCount; j++)
            {
                GameObject cell = Instantiate(Resources.Load<GameObject>("cell"), new Vector2(x, y), Quaternion.identity, transform);
                cell.transform.DOScale(Vector3.one * 0.75f, 0.25f);
                x++;
            }
            x = 0 - gridCount / 2;
            y--;
        }
    }

    public void CheckNeighbors()
    {

    }
}
