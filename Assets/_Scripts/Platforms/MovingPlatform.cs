using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrogNinja.Platforms
{
    public class MovingPlatform : BasePlatform
    {
        [SerializeField] private float bounceForce;
        [SerializeField] private float speed;
        [SerializeField] private SpriteRenderer platformSprite;
        [SerializeField] private Rigidbody2D platformRigidbody;
        [SerializeField] protected Vector2 velocity;

        private Camera mainCamera;

        private void Awake()
        {
            mainCamera = Camera.main;
            velocity = new Vector2(speed, 0);
        }

        private void FixedUpdate()
        {
            Move();
        }
        protected override void HandleCollision(Collision2D collision)
        {
            collision.rigidbody.velocity = Vector2.zero;
            collision.rigidbody.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
        }

        private void Move()
        {
            platformRigidbody.velocity = velocity;

            float screenPositionX = mainCamera.WorldToViewportPoint(transform.position).x;

            if (screenPositionX < 0.03f)
            {
                velocity.x = speed;
            }
            else if (screenPositionX > 0.97f)
            {
                velocity.x = -speed;
            }
        }
    }
}

