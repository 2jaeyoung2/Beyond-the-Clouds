using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseInput : MonoBehaviour
{
    private static MouseInput _instance;

    private Ray ray;

    private bool hasPos = false;

    #region Properties

    public static MouseInput Instance
    {
        get
        {
            return _instance;
        }
    }

    public RaycastHit Info { get; private set; }

    #endregion

    private void Awake()
    {
        #region Singleton
        ///////////////////////////////////////////
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);

            return;
        }
        else
        {
            _instance = this;

            DontDestroyOnLoad(gameObject);
        }
        ///////////////////////////////////////////
        #endregion
    }

    private void Update()
    {
        if (hasPos == true)
        {
            SetCursorPos();
        }
    }

    public void OnGetCursorPos(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            hasPos = true;
        }

        if (ctx.phase == InputActionPhase.Canceled)
        {
            hasPos = false;
        }
    }

    private void SetCursorPos()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.black);

        int floorLayerMask = LayerMask.GetMask("FLOOR");

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, floorLayerMask))
        {
            Info = hit;
        }
    }
}
