using UnityEngine;

namespace FrogNinja.Platforms
{
    public class BouncyPlatform : BasePlatform
    {
        [SerializeField] float bounceForce;
        protected override void HandleCollision(Collision2D collision)
        {
            collision.rigidbody.velocity = Vector2.zero;
            collision.rigidbody.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
        }
    }
}

