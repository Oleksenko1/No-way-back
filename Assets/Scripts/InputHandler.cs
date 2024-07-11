using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputHandler : MonoBehaviour
{
    public Camera mainCamera;

    public UnityEvent OnShootPressed = new UnityEvent();
    public UnityEvent OnReloadPressed = new UnityEvent();
    public UnityEvent<Vector2> OnMoveBody = new UnityEvent<Vector2>();
    public UnityEvent<Vector2> OnRotateBody = new UnityEvent<Vector2>();

    private void Awake()
    {
        if(mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }
    private void Update()
    {
        GetMoveBody();
        GetRotateBody();
        GetShootingInput();
        GetReloadInput();
    }
    public void GetMoveBody()
    {
        Vector2 movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        OnMoveBody?.Invoke(movementVector.normalized);
    }
    public void GetReloadInput()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            OnReloadPressed?.Invoke();
        }
    }
    public void GetShootingInput()
    {
        if(Input.GetMouseButtonDown(0)) // Sends signal on pressing LMB
        {
            OnShootPressed?.Invoke();
        }
    }
    private void GetRotateBody()
    {
        OnRotateBody?.Invoke(GetMousePosition()); // Sends signal with a Mouse Position vector every frame
    }
    private Vector2 GetMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = mainCamera.nearClipPlane;
        Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        return mouseWorldPosition;
    }
    
    

}
