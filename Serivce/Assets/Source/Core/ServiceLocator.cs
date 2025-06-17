using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator<T> : IServiceLocator where T : IService
{
    private readonly Dictionary<Type, T> _services = new Dictionary<Type, T>();

    public bool TryGetService<T>(out T service) where T : class, IService 
    {
        service = default;

        if (_services.ContainsKey(typeof(T))) 
        {
            service = _services[typeof(T)] as T; 
            return true;
        }

        return false;
    }
    
    public void AddService(T service)
    {
        _services.Add(typeof(T), service);
    }

    public void RemoveService<T>( )
    {
        _services.Remove(typeof(T)); 
    }

   
}
