using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    #region Variables
    Vector3 camPos;
    #endregion

    #region Singleton
    public static CameraManager instance = null;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    public void SetCamPos(int gridCount)
    {
        if (gridCount % 2 == 0)
        {
            camPos = new Vector3(-0.5f, 0, gridCount * (-1) * 2);
            transform.position = camPos;
        }
        else
        {
            camPos = new Vector3(0, 0, gridCount * (-1) * 2);
            transform.position = camPos;
        }
    }
}
