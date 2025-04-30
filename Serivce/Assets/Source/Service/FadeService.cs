using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeService : IFadeService
{
    public void FadeIn(CanvasGroup canvas, float duration)
    {
        canvas.DOFade(1f, duration);
    }

    public void FadeOut(CanvasGroup canvas, float duration, Action fadeOutCallback = null)
    {
        canvas.DOFade(0f, duration)
            .OnComplete(() => fadeOutCallback?.Invoke());
    }
}
