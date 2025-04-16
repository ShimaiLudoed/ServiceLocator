using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelView : MonoBehaviour
{
    [SerializeField] private Button panelButton;

    public void Bind(Action callback = null)
    {
        if (callback != null)
            panelButton.onClick.AddListener(() => callback.Invoke());
    }
    public void Expose()
    {
        panelButton.onClick.RemoveListener(Click);
    }

    private void Click()
    {
        Debug.Log("Click");
    }
}
