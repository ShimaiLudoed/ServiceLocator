using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IFadeService : IService
{
  void FadeIn(CanvasGroup canvas, float duration);
  void FadeOut(CanvasGroup canvas, float duration);
}
