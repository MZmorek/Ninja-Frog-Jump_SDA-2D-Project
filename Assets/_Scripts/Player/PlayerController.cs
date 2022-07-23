using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private Rigidbody2D playerRigidbody;

    private float horizontalInput;
    private Vector3 playerVelocity;
    private Vector3 screenPosition;
    private Camera mainCamera;
    private bool wrapScreen;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        screenPosition = mainCamera.WorldToViewportPoint(transform.position);
        EventManager.OnUpdatePlayerPosition(transform.position);
        HandleScreenWrap();
        GameOverConditions();
    }

    private void HandleScreenWrap()
    {
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

    private void GameOverConditions()
    {
        if (screenPosition.y < -0.08f)
        {
            EventManager.OnPlayerFallenOff();
            SceneManager.LoadScene("SampleScene");
        }
    }

    private void FixedUpdate()
    {
        playerVelocity = playerRigidbody.velocity;
        playerVelocity.x = horizontalInput * horizontalSpeed;
        playerRigidbody.velocity = playerVelocity;

        if (wrapScreen)
        {
            playerRigidbody.MovePosition(Camera.main.ViewportToWorldPoint(screenPosition));
        }  
    }
}