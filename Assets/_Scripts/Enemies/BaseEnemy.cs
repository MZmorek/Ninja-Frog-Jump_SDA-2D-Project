using System.Collections;
using System.Collections.Generic;
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
            
        }

        protected abstract void Move();
    }
}