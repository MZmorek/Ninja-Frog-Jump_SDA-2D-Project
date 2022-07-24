using UnityEngine;

namespace FrogNinja.Player
{
    public class PlayerShootingController : MonoBehaviour
    {
        [SerializeField] private PlayerBullet bulletPrefab;
        [SerializeField] private Rigidbody2D playerRigidbody;

        private void Update()
        {
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

            spawnedBullet.Shoot(direction);
        }
    }
}
