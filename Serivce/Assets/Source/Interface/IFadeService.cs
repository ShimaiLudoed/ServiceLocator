using System;
using UnityEngine;
using UnityEngine.UI;

public interface IFadeService : IService
{
 public void FadeIn(CanvasGroup canvas, float duration);
 public void FadeOut(CanvasGroup canvas, float duration, Action fadeOutCallback = null);
}
