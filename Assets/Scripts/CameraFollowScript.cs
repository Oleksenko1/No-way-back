using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public Transform playerTransform;
    public float speed;
    public float maxDistanceX;
    public float maxDistanceY;

    private Vector2 mousePos;

    private InputHandler inputHandler;
    private void Awake()
    {
        inputHandler = GameObject.Find("Player").GetComponent<InputHandler>();
    }

    private void FixedUpdate() 
    {
        //Calculate and change position of the camera
        Vector2 playerPos = new Vector3(playerTransform.position.x, playerTransform.position.y);
        Vector2 targetPos = (playerPos - mousePos)/2;
        targetPos += mousePos;
        
        targetPos.x = Mathf.Clamp(targetPos.x, playerPos.x - maxDistanceX, playerPos.x + maxDistanceX);
        targetPos.y = Mathf.Clamp(targetPos.y, playerPos.y - maxDistanceY, playerPos.y + maxDistanceY);

        //transform.position =  Vector3.Lerp(transform.position, new Vector3(targetPos.x, targetPos.y, -10), speed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, new Vector3(targetPos.x, targetPos.y, -10), speed * Time.deltaTime);
    }
    public void HandleMousePosition(Vector2 mousePos) // Activates throw inputHandler event system
    {
        this.mousePos = mousePos;
    }
}
