using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PanelController : UIController
{
    private readonly PanelView _panel;

    [Inject]
    public PanelController(PanelView panel)
    {
        _panel = panel;
    }
    public override void Enter()
    {
        _panel.Open();
        _panel.Bind(ChangeController);
    }

    public override void Exit()
    {
        _panel.Close();
        _panel.Expose(ChangeController);
    }
    private void ChangeController()
    {
        _switcher.ChangeState<OpenController>();
    }
}
