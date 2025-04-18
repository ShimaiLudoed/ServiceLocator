using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelView : MonoBehaviour
{
    [SerializeField] private Button panelButton;
    [SerializeField] private GameObject panel;

    public void Bind(Action callback = null)
    {
        if (callback != null)
            panelButton.onClick.AddListener(() => callback.Invoke());
    }
    public void Expose(Action callback = null)
    {
        panelButton.onClick.RemoveListener(() => callback.Invoke());
    }
    public void Close()
    {
        panel.SetActive(false);
    }
    public void Open()
    {
        panel.SetActive(true);
    }
}
