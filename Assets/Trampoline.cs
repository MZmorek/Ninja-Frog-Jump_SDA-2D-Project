using UnityEngine;

namespace FrogNinja.Platforms
{
    public class Trampoline : BasePlatform
    {
        [SerializeField] float doubleBounce;
        public Animator trampolineAnimator;

        protected override void HandleCollision(Collision2D collision)
        {
            collision.rigidbody.velocity = Vector2.zero;
            trampolineAnimator.SetBool("playerCollision", true);
            collision.rigidbody.AddForce(Vector2.up * doubleBounce, ForceMode2D.Impulse);
            trampolineAnimator.SetBool("playerCollision", false);
        }
    }
}
