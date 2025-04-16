using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IFadeService 
{
    public void FadeIn(CanvasGroup canvas, float duration);
    public void FadeOut(CanvasGroup canvas, float duration);
}
