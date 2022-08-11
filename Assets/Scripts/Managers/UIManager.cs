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
    [SerializeField] EndPanel endPanel;
    
    [HideInInspector] public int scoreCount = 0;
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
        endPanel.Active(false);
    }

    void Update()
    {
        gamePanel.scoreText.text = "Score : " + scoreCount;

        if (scoreCount == 3)
        {
            Success();
        }
    }

    public void CreateGridButton()
    {
        gridCount = Convert.ToInt32(startPanel.gridCountText.text);

        gamePanel.ActiveSmooth(true);
        startPanel.ActiveSmooth(false);
        GridManager.instance.GenerateGrid();
    }

    void Success()
    {
        gamePanel.scoreText.DOFade(0, 0.25f).OnComplete(() =>
        {
            gamePanel.Active(false);
            endPanel.Active(true);
            scoreCount = 0;
        });
    }
}
