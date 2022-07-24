using UnityEngine;

namespace FrogNinja.Player
{
    public class PlayerBullet : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Rigidbody2D bulletRigidbody;
        [SerializeField] private AudioClip impactSound;

        private Vector3 direction = Vector3.zero;

        public void Shoot(Vector3 newDirection)
        {
            direction = newDirection;
            Invoke("Die", 3f);
        }

        private void FixedUpdate()
        {
            bulletRigidbody.velocity = direction * speed;
        }

        private void Die()
        {
            Destroy(gameObject);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Die();
            AudioSystem.PlaySFX_Global(impactSound);
        }
    }
}

