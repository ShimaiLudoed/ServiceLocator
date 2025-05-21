using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Pool<T> : IPool<T> where T : MonoBehaviour, IPoolable
{
    private readonly DiContainer _container;
    private readonly Queue<T> _pool = new();
    private readonly int _startPoolSize;
    public int Count
    {
        get { return _pool.Count; }
    }
    public Pool(DiContainer container, int poolSize, T bullet)
    {
       _container = container;
      _startPoolSize = poolSize;
        Debug.Log(bullet);
       InitPool(bullet);
    }
    public void InitPool(T prefab)
    {
        for (int i = 0; i < _startPoolSize; i++)
        {
            T bulletInit = _container.InstantiatePrefabForComponent<T>(prefab);
            bulletInit.gameObject.SetActive(false);
            bulletInit.OnBulletDisable += ReturnToPool;


            ReturnToPool(bulletInit);
        }
    }
    private void ReturnToPool(IPoolable obj)
    {
        T bullet = obj as T;
        if (bullet != null)
        {
            ReturnToPool(bullet);
        }
    }
    public bool TryGetFromPool(out T bullet)
    {
        return _pool.TryDequeue(out bullet);
    }
    public void ReturnToPool(T bullet)
    {
        bullet.gameObject.SetActive(false);
        _pool.Enqueue(bullet);
    }
}