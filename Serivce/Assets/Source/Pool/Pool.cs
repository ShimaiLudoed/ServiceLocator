using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Pool<T> : IPool<T> where T : MonoBehaviour, IPoolable
{
    private ISoundPlayer _soundPlayer;
    private TransformData _transformData;
    private Bullet.BulletFactory _bulletFactory;
    private readonly Queue<T> _pool = new();
    private readonly int _startPoolSize;
    public int Count
    {
        get { return _pool.Count; }
    }
    [Inject]
    public Pool(int poolSize, T bullet, Bullet.BulletFactory bulletFactory, TransformData michen, ISoundPlayer soundPlayer)
    {
        _soundPlayer = soundPlayer;
        _startPoolSize = poolSize;
        _bulletFactory = bulletFactory;
        _transformData = michen;
        InitPool(bullet);
    }
    public void InitPool(T prefab)
    {
        for (int i = 0; i < _startPoolSize; i++)
        {
            T bulletInit = _bulletFactory.Create(_soundPlayer,_transformData) as T;
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