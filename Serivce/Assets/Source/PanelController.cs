using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : UIController
{
    private PanelView _panel;

    public PanelController(PanelView panel, UISwitcher<UIController> switcher)
    {
        _panel = panel;
        _switcher = switcher;
    }
    public override void Enter()
    {
        _panel.Bind();
    }

    public override void Exit()
    {
        _panel.Expose();
    }
}
