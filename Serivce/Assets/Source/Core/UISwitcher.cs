using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UISwitcher<T> : IUISwitcher where T : UIController 
{
    private Dictionary<Type, T> _controllers;
    public T CurrentController;

    public UISwitcher(OpenController openController, PanelController panelController)
    {
        _controllers = new Dictionary<Type, T>()
            {
                {typeof(OpenController),openController as T },
                {typeof(PanelController),panelController as T}
            };

        foreach (var controller in _controllers.Values)
        {
            controller.SetSwitcher(this as UISwitcher<UIController>);
        }
    }

    public void ChangeState<T>()
    {
        if (CurrentController != null)
        {
            CurrentController.Exit();
        }
        CurrentController = _controllers[typeof(T)];
        CurrentController.Enter();
    }

    private Type MoveNext()
    {
        int nextId = 0;
        for (int i = 0; i < _controllers.Count; i++)
        {
            if (_controllers.Values.ElementAt(i).Equals(CurrentController))
            {
                if (_controllers.Keys.Count > i + 1)
                {
                    nextId = i + 1;
                }
            }
        }
        return _controllers.Keys.ElementAt(nextId);
    }
}
