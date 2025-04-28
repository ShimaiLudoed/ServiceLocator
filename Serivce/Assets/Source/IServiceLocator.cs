using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IServiceLocator
{
    bool TryGetService<T>(out T service) where T : class, IService; 
    void RemoveService<T>();
}
