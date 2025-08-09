using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private bool _isTargeting = false;

    private bool _isZoom = false;

    #region properties

    public bool IsShoot
    {
        get => _isTargeting;

        private set
        {
            _isTargeting = value;
        }
    }

    public bool IsZoom
    {
        get => _isZoom;

        set
        {
            _isZoom = value;
        }
    }

    #endregion

    private void Update()
    {
        if (IsShoot == true || IsZoom == true)
        {
            Shoot();
        }
    }

    public void OnAttack(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            IsShoot = true;
        }

        if (ctx.phase == InputActionPhase.Canceled)
        {
            IsShoot = false;
        }
    }

    public void OnZoom(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            IsZoom = true;
        }

        if (ctx.phase == InputActionPhase.Canceled)
        {
            IsZoom = false;
        }
    }

    private void Shoot()
    {
        // 임시 코드
        transform.LookAt(SetTargetPos());
    }

    // 임시 타겟팅
    private Vector3 SetTargetPos()
    {
        Vector3 tempTarget = MouseInput.Instance.Info.point;

        tempTarget.y = transform.position.y;

        return tempTarget;
    }
}
