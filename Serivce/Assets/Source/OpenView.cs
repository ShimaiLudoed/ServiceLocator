using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenView : MonoBehaviour
{
    [SerializeField] private Button openButton;

    public void Bind()
    {
        openButton.onClick.AddListener(Click);
    }
    public void Expose()
    {
        openButton.onClick.RemoveListener(Click);
    }

    private void Click()
    {
        
    }
}
