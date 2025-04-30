using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class OpenView : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Button openButton;
    private IFadeService _fadeService;
    private ISoundPlayer _soundPlayer;
    private const float closeDuration = 0;
    private const float openDuration = 1;

    [Inject]
    public void Construct(IFadeService fadeService, ISoundPlayer playerSound)
    {
        _fadeService = fadeService;
        _soundPlayer = playerSound;
    }

    public void Bind(Action callback = null)
    {
        if (callback != null)
            openButton.onClick.AddListener(() => callback.Invoke());
    }
    public void Expose(Action callback = null)
    {
        openButton.onClick.RemoveAllListeners();
    }

    public void Close()
    {
        _soundPlayer.PlayCloseSound();
        _fadeService.FadeOut(canvasGroup, closeDuration);
        openButton.gameObject.SetActive(false);
    }
    public void Open()
    {
        _soundPlayer.PlayOpenSound();
        _fadeService.FadeIn(canvasGroup, openDuration);
        openButton.gameObject.SetActive(true);
    }
}
