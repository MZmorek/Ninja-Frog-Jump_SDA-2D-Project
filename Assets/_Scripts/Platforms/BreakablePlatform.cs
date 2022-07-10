using UnityEngine;

namespace FrogNinja.Platforms
{
    public class BreakablePlatform : BasePlatform
    {
        protected override void HandleCollision(Collision2D collision)
        {
            Destroy(gameObject);
        }
    }
}
