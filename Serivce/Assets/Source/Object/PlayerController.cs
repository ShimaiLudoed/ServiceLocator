using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    private readonly PlayerView _playerView;

    [Inject]

    public PlayerController(PlayerView playerView)
    {
        _playerView = playerView;
    }
    public void Shoot()
    {
        _playerView.Shoot();
    }
}
