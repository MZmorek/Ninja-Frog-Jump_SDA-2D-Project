using UnityEngine;

namespace FrogNinja.Player
{
    [RequireComponent(typeof(PlayerController))]
    public class PlayerShootingController : MonoBehaviour
    {
        [SerializeField] private PlayerBullet bulletPrefab;
        [SerializeField] private Rigidbody2D playerRigidbody;
        [SerializeField] private AudioClip shootingSound;
        private PlayerController playerController;
        private Camera mainCamera;

        private void Awake()
        {
            playerController = GetComponent<PlayerController>();
            mainCamera = Camera.main;
        }

        private void Update()
        {
            if (!playerController.IsActive)
            {
                return;
            }
            if (Input.GetMouseButtonDown(0))
            {
                SpawnBullet();
            }
        }

        private void SpawnBullet()
        {
            PlayerBullet spawnedBullet = Instantiate<PlayerBullet>(bulletPrefab, 
                playerRigidbody.position, Quaternion.identity);

            Vector3 direction = Vector3.up;

            AudioSystem.PlaySFX_Global(shootingSound);

            Vector3 worldMousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            worldMousePosition.z = transform.position.z;

            direction = worldMousePosition - transform.position;
            spawnedBullet.Shoot(direction.normalized);
            
        }
    }
}
