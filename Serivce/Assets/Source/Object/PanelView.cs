using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelView : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Button panelButton;
    [SerializeField] private GameObject panel;
    private IFadeService _fadeService;
    private ISoundPlayer _soundPlayer;

    public void Construct(IServiceLocator service)
    {
        if (service.TryGetService(out IFadeService fadeService))
        {
            _fadeService = fadeService;
        }

        if (service.TryGetService(out ISoundPlayer soundPlayer))
        {
            _soundPlayer = soundPlayer;
        }
    }

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
