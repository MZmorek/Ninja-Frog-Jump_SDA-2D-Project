using UnityEngine;
using FrogNinja.LevelGeneration;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private Rigidbody2D playerRigidbody;

    private float horizontalInput;
    private Vector3 playerVelocity;
    private Vector3 screenPosition;
    private Camera mainCamera;
    private bool wrapScreen;
    private bool active = false;

    private void Awake()
    {
        LevelGenerator.LevelGenerated += LevelGenerator_LevelGenerated;
    }

    private void OnDestroy()
    {
        LevelGenerator.LevelGenerated -= LevelGenerator_LevelGenerated;
    }

    private void LevelGenerator_LevelGenerated(Vector3 obj)
    {
        transform.position = obj;
    }

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (!active)
        {
            return;
        }

        horizontalInput = Input.GetAxis("Horizontal");
        
        EventManager.OnUpdatePlayerPosition(transform.position);
        HandleScreenWrap();
        GameOverConditions();
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

    private void GameOverConditions()
    {
        if (screenPosition.y < -0.08f)
        {
            EventManager.OnPlayerFallenOff();
        }
    }

    private void FixedUpdate()
    {
        if (!active)
        {
            return;
        }
        playerVelocity = playerRigidbody.velocity;
        playerVelocity.x = horizontalInput * horizontalSpeed;
        playerRigidbody.velocity = playerVelocity;

        if (wrapScreen)
        {
            playerRigidbody.MovePosition(Camera.main.ViewportToWorldPoint(screenPosition));
        }
    }

    public void SwitchState(bool state)
    {
        active = state;

        if (playerRigidbody != null)
        {
            playerRigidbody.simulated = state;
        }
    }

}