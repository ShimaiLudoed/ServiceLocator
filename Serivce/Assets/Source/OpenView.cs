using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenView : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Button openButton;
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
            openButton.onClick.AddListener(() => callback.Invoke());
    }
    public void Expose(Action callback = null)
    {
        openButton.onClick.RemoveListener(() => callback.Invoke());
    }

    public void Close()
    {
        _soundPlayer.PlayCloseSound();
        _fadeService.FadeOut(canvasGroup,1);
        openButton.gameObject.SetActive(false);
    }
    public void Open()
    {
        _soundPlayer.PlayOpenSound();
        _fadeService.FadeIn(canvasGroup,0);
        openButton.gameObject.SetActive(true);
    }
}
