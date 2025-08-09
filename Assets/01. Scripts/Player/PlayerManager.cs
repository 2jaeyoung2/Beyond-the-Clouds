using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private float _moveSpeed;

    public float MoveSpeed
    {
        get => _moveSpeed;

        private set
        {
            _moveSpeed = value;
        }
    }

    private void Awake()
    {
        _moveSpeed = 5f;
    }
}
