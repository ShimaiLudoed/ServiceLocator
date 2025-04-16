using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootStrapper : MonoBehaviour
{
    [SerializeField] private PanelView panel;
    [SerializeField] private OpenView openView;
    private PanelController _panelController;
    private OpenController _openController;
    private UISwitcher<UIController> _UIswitcher;

    private void Start()
    {
        _panelController = new PanelController(panel);
        _openController = new OpenController(openView);
        _UIswitcher = new UISwitcher<UIController>(_openController, _panelController);
        _UIswitcher.ChangeState<OpenController>();
    }
}
