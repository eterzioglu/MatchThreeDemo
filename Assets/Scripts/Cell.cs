using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cell : MonoBehaviour
{
    #region Variables
    [SerializeField] GameObject cross;
    public bool isChildEnable = false;
    public int x, y;
    #endregion

    void OnMouseDown()
    {
        if (isChildEnable) return;

        CrossEnabled(true);
    }

    public void CrossEnabled(bool enabled)
    {
        int scale = enabled ? 1 : 0;
        cross.transform.DOScale(Vector3.one * scale, 0.25f).OnComplete(() =>
        {
            isChildEnable = enabled;
            ControlCells();
        });
    }

    void ControlCells()
    {
        var neighbors = GridManager.instance.ControlNeighborCells(x, y);

        if (neighbors.Count >= 3)
        {
            foreach (var neighbor in neighbors)
            {
                neighbor.CrossEnabled(false);
            }
        }
    }
}
