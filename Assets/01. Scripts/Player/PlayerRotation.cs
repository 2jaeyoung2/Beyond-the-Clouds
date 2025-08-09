using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement _playerMovement;

    [SerializeField]
    private PlayerAttack _playerAttack;

    private IPlayerRotationStates currentRotationState;

    private float _rotateSpeed;

    #region properties

    public PlayerAttack PlayerAttack
    {
        get => _playerAttack;
    }

    public PlayerMovement PlayerMovement
    {
        get => _playerMovement;
    }

    public float RotateSpeed
    {
        get => _rotateSpeed;

        set
        {
            _rotateSpeed = value;
        }
    }
    #endregion

    private void Start()
    {
        ChangeStateTo(new NormalRotateState());

        RotateSpeed = 25f;
    }

    private void FixedUpdate()
    {
        currentRotationState.UpdatePerState();
    }

    public void ChangeStateTo(IPlayerRotationStates states)
    {
        currentRotationState?.ExitState();

        currentRotationState = states;

        currentRotationState.EnterState(this);
    }
}