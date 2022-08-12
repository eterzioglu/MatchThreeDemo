using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    #region Variables
    Vector3 camPos;
    Camera cam;
    float refRatio = (float)1080 / 1920;
    #endregion

    #region Singleton
    public static CameraManager instance = null;
    private void Awake()
    {
        if (instance == null) instance = this;
    }
    #endregion

    private void Start()
    {
        cam = gameObject.GetComponent<Camera>();
    }

    public void SetCamPos(int gridCount)
    {
        float currentRatio = (float)Screen.width / Screen.height;
        float ratio = currentRatio / refRatio;
        cam.orthographicSize = gridCount / ratio;

        float posX = gridCount % 2 == 0 ? -0.5f : 0;
        transform.position = new Vector3(posX, transform.position.y, transform.position.z);
    }
}
