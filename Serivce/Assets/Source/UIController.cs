using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIController 
{
    protected UISwitcher<UIController> _switcher { get; set; }

    public abstract void Enter();
    public abstract void Exit();
}
