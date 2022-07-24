using FrogNinja.Player;
using UnityEngine;

namespace FrogNinja.Enemies
{
    public abstract class BaseEnemy : MonoBehaviour
    {
        [SerializeField] protected Rigidbody2D enemyRigidbody;
        [SerializeField] protected float speed;
        [SerializeField] protected Vector2 velocity;

        [SerializeField] protected SpriteRenderer enemySprite;

        protected virtual void FixedUpdate()
        {
            Move();
        }

        protected virtual void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.rigidbody.GetComponent<PlayerController>() != null)
            {
                EventManager.OnEnemyHitPlayer();
            }
            if (collision.rigidbody.GetComponent<PlayerBullet>() != null)
            {
                enemyRigidbody.gameObject.SetActive(false);
                EventManager.OnEnemyDied();

            }
        }

        protected abstract void Move();
    }
}