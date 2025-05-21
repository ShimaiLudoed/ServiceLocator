using System;
using UnityEngine;
using Zenject;
public class Bullet : MonoBehaviour, IPoolable
{
    [SerializeField] private LayerMask wallMask;
    [SerializeField] private float speed;
    [SerializeField] private float lifetime;
    private Transform _michen;
    private ISoundPlayer _soundPlayer;
    private float _curTime;
    public event Action<IPoolable> OnBulletDisable;
    [Inject]
    public void Construct(ISoundPlayer soundPlayer, TransformData transformData)
    {
        _michen = transformData.Michen;
        _soundPlayer = soundPlayer;
        Debug.Log("пиф паф " + _soundPlayer);
    }
    private void Start() 
    {
        Debug.Log(_soundPlayer);
        _curTime = lifetime;
        _soundPlayer.PlayShootSound();
    }
    private void Update()
    {
        transform.position += _michen.transform.position * (speed * Time.deltaTime);
        if (_curTime <= 0)
        {
            Disable();
        }
        else
        {
            _curTime -= Time.deltaTime;
        }
    }
    private void Disable()
    {
        OnBulletDisable?.Invoke(this);
        gameObject.SetActive(false); 
    }
    public void Obstacle()
    {
        _soundPlayer?.PlayObstacleSound();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (LayerMaskCheck.ContainsLayer(wallMask, other.gameObject.layer))
        {
            Obstacle();
            Disable(); 
        }
    }
}