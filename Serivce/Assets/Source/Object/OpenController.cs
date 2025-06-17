using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenController : UIController 
{
    private OpenView _open;

    public OpenController(OpenView open)
    {
        _open = open;
    }   

    public override void Enter()
    {
        _open.Open();
        _open.Bind(ChangeController);
    }

    public override void Exit()
    {
        _open.Close();
        _open.Expose(ChangeController);
    }
    private void ChangeController()
    {
        _switcher.ChangeState<PanelController>();
    }
}
