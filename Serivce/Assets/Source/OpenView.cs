using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenView : MonoBehaviour
{
    [SerializeField] private Button openButton;

    public void Bind(Action callback = null)
    {
        if (callback != null)
            openButton.onClick.AddListener(() => callback.Invoke());
    }
    public void Expose(Action callback = null)
    {
        openButton.onClick.RemoveListener(() => callback.Invoke());
    }

    public void Close()
    {
        openButton.gameObject.SetActive(false);
    }
    public void Open()
    {
        openButton.gameObject.SetActive(true);
    }
}
