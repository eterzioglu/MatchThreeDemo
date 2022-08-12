using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cell : MonoBehaviour
{
    [SerializeField] GameObject cross;
    bool isChildEnable = false;

    void OnMouseDown()
    {
        if (isChildEnable) return;

        CrossEnabled(true);
        
    }

    public void CrossEnabled(bool enabled)
    {
        int scale = enabled ? 1 : 0;
        cross.transform.DOScale(Vector3.one * scale, 0.25f);
        isChildEnable = enabled;
    }
}
