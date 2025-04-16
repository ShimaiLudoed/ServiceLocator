using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelView : MonoBehaviour
{
    [SerializeField] private Button panelButton;

    public void Bind()
    {
        panelButton.onClick.AddListener(Click);
    }
    public void Expose()
    {
        panelButton.onClick.RemoveListener(Click);
    }

    private void Click()
    {
        Debug.Log("Click");
    }
}
