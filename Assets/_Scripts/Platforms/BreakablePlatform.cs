using UnityEngine;

namespace FrogNinja.Platforms
{
    public class BreakablePlatform : BasePlatform
    {
        [SerializeField] private SpriteRenderer mySprite;
        protected override void HandleCollision(Collision2D collision)
        {
            collision.otherCollider.enabled = false;
            mySprite.enabled = false;
        }
    }
}
