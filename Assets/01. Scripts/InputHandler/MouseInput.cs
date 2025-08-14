using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseInput : MonoBehaviour
{
    private static MouseInput _instance;

    private Ray ray;

    private bool hasPos = false;

    [Header("Input Actions")]
    [SerializeField] private InputActionReference getCursorPosAction; // 인스펙터에서 연결

    #region Properties

    public static MouseInput Instance => _instance;

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

    private void OnEnable()
    {
        if (getCursorPosAction != null)
        {
            getCursorPosAction.action.performed += OnGetCursorPos;

            getCursorPosAction.action.canceled += OnGetCursorPosCanceled;

            getCursorPosAction.action.Enable();
        }
    }

    private void OnDisable()
    {
        if (getCursorPosAction != null)
        {
            getCursorPosAction.action.performed -= OnGetCursorPos;

            getCursorPosAction.action.canceled -= OnGetCursorPosCanceled;

            getCursorPosAction.action.Disable();
        }
    }

    private void Update()
    {
        if (hasPos == true)
        {
            SetCursorPos();
        }
    }

    private void OnGetCursorPos(InputAction.CallbackContext ctx)
    {
        hasPos = true;
    }

    private void OnGetCursorPosCanceled(InputAction.CallbackContext ctx)
    {
        hasPos = false;
    }

    private void SetCursorPos()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.green);

        int floorLayerMask = LayerMask.GetMask("FLOOR");

        if (Physics.Raycast(ray, out RaycastHit hit, 100f, floorLayerMask))
        {
            Info = hit;
        }
    }
}
