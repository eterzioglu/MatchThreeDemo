using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    #region Variables
    [SerializeField] StartPanel startPanel;
    [SerializeField] GamePanel gamePanel;
    [SerializeField] EndPanel endPanel;
    [SerializeField] InputField gridCount;
    [SerializeField] Text scoreText;
    [HideInInspector] public int scoreCount = 0;
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
        scoreText.text = "Score : " + scoreCount;

        if (scoreCount == 3)
        {
            Success();
        }
    }

    public void CreateGridButton()
    {
        gamePanel.ActiveSmooth(true);
        startPanel.ActiveSmooth(false);
    }

    void Success()
    {
        scoreText.DOFade(0, 0.25f).OnComplete(() =>
        {
            gamePanel.Active(false);
            endPanel.Active(true);
            scoreCount = 0;
        });
    }
}
