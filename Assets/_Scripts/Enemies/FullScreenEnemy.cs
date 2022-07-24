using UnityEngine;
namespace FrogNinja.Enemies
{
    public class FullScreenEnemy : BaseEnemy
   {
        private Camera mainCamera;

        private void Awake()
        {
            mainCamera = Camera.main;
            velocity = new Vector2(speed, 0);
        }

        protected override void Move()
        {
            enemyRigidbody.velocity = velocity;

            float screenPositionX = mainCamera.WorldToViewportPoint(transform.position).x;

            if (screenPositionX < 0.03f)
            {
                velocity.x = speed;
                enemySprite.flipX = true;
            }
            else if (screenPositionX > 0.97f)
            {
                velocity.x = -speed;
                enemySprite.flipX = false;
            }
        }
    }
}

