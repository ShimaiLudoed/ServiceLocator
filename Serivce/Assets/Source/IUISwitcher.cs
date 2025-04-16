using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUISwitcher 
{
    public void ChangeState<T>();
}
