using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    #region Variables
    [SerializeField] StartPanel startPanel;
    [SerializeField] GamePanel gamePanel;

    [HideInInspector] public int gridCount = 0;
    #endregion

    #region Singleton
    public static UIManager instance = null;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    void Start()
    {
        startPanel.Active(true);
        gamePanel.Active(false);
    }

    public void CreateGridButton()
    {
        gamePanel.ActiveSmooth(true);
        startPanel.ActiveSmooth(false);

        gridCount = Convert.ToInt32(startPanel.gridCountText.text);
        GridManager.instance.GenerateGrid(gridCount);
    }
}
