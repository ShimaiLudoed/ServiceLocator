using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BootStrapper : MonoBehaviour
{
    private UISwitcher<UIController>_UIswitcher;

    [Inject]
    public void Construct(UISwitcher<UIController> UIswitcher)
    {
        _UIswitcher = UIswitcher; 
    }

    private void Start()
    {
        _UIswitcher.ChangeState<OpenController>();
    }
}
