using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class InputListener : MonoBehaviour
{
    private PlayerController _playerController;

    [Inject]
    public void Construct(PlayerController playerController)
    {
        _playerController = playerController;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _playerController.Shoot();
        }    
    }
}
