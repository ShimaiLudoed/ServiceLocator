using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PanelView : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Button panelButton;
    [SerializeField] private GameObject panel;
    private IFadeService _fadeService;
    private ISoundPlayer _soundPlayer;
    private const float openDuration = .5f;

    [Inject]
    public void Construct(IFadeService fadeService, ISoundPlayer playerSound)
    {
        _fadeService = fadeService;
        _soundPlayer = playerSound;
    }

    public void Bind(Action callback = null)
    {
        if (callback != null)
            panelButton.onClick.AddListener(() => callback.Invoke());
    }
    public void Expose(Action callback = null)
    {
        panelButton.onClick.RemoveAllListeners();
    }
    public void Close()
    {
        _fadeService.FadeOut(canvasGroup, openDuration, () => panel.SetActive(false));
    }
    public void Open()
    {
        panel.SetActive(true);
        _fadeService.FadeIn(canvasGroup, openDuration);
    }
}
