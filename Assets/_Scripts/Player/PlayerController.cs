using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float horizontalSpeed;
    [SerializeField] Rigidbody2D playerRigidbody;

    float horizontalInput;
    Vector3 playerVelocity, screenPosition;
    Camera mainCamera;
    bool wrapScreen;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        HandleScreenWrap();
    }

    private void HandleScreenWrap()
    {
        screenPosition = mainCamera.WorldToViewportPoint(transform.position);

        if (screenPosition.x < -0.03f)
        {
            screenPosition.x = 1.03f;
            wrapScreen = true;
        }
        else if (screenPosition.x > 1.03f)
        {
            screenPosition.x = -0.03f;
            wrapScreen = true;
        }
        else
        {
            wrapScreen = false;
        }
    }

    private void FixedUpdate()
    {
        playerVelocity = playerRigidbody.velocity;
        playerVelocity.x = horizontalInput * horizontalSpeed;
        playerRigidbody.velocity = playerVelocity;

        if (wrapScreen)
            playerRigidbody.MovePosition(Camera.main.ViewportToWorldPoint(screenPosition));
    }
}