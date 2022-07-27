using UnityEngine;

namespace FrogNinja.Platforms
{
    public class BreakablePlatform : BasePlatform
    {
        [SerializeField] private SpriteRenderer platformSprite;
        protected override void HandleCollision(Collision2D collision)
        {
            collision.otherCollider.enabled = false;
            platformSprite.enabled = false;
        }
    }
}
