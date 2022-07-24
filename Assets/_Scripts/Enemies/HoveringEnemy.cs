using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrogNinja.Enemies
{
    public class HoveringEnemy : BaseEnemy
    {
        [SerializeField] private float movementRangeX;
        private Vector2 movementRange;

        private void Awake()
        {
            movementRange = new Vector2(transform.position.x - movementRangeX,
                transform.position.x + movementRangeX);

            velocity = new Vector2(speed, 0);
            
        }

        protected override void Move()
        {
            enemyRigidbody.velocity = velocity;

            float posX = transform.position.x;

            if (posX < movementRange.x)
            {
                velocity.x = speed;
                enemySprite.flipX = true;
            }
            else if (posX > movementRange.y)
            {
                velocity.x = -speed;
                enemySprite.flipX = false;
            }
        }
    }

}
