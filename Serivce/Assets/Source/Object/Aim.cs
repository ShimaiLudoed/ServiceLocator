using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Aim : MonoBehaviour
{
    private Transform _player;

    [Inject]
    public void Consrtuct(TransformData transformData)
    {
        _player = transformData.Player;
    }

    public void Update()
    {
        Vector2 targetPosition = _player.position;
        targetPosition.x = transform.position.x;
        transform.position = targetPosition;
    }
}
