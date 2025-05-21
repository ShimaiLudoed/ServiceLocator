using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Bullet : MonoBehaviour, IPoolable
{
  [SerializeField] private float speed;
  [SerializeField] private float lifetime;
  private ISoundPlayer _soundPlayer; 
  private float _curTime;
  public event Action<IPoolable> OnBulletDisable;

  [Inject]
  public void Construct(ISoundPlayer soundPlayer)
  {
    _soundPlayer = soundPlayer;
  }
  
  private void OnEnable()
  {
    Debug.Log(_soundPlayer);
    _curTime = lifetime; 
    _soundPlayer.PlayShootSound(); 
  }

  private void Update()
  {
    transform.position = Vector3.forward * (speed * Time.deltaTime);
        
    if (_curTime <= 0)
    {
      Disable();
    }
    else
    {
      _curTime -= Time.deltaTime;
    }
  }
  private  void Disable()
  {
    OnBulletDisable?.Invoke(this);
  }

  public void Obstacle()
  {
    _soundPlayer.PlayObstacleSound();
  }

  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.CompareTag("Destructible"))
    {
      Obstacle();
    }
  }
  
}
