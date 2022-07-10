using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator playerAnimator;
    public SpriteRenderer playerSprite;
    public Rigidbody2D playerRigidbody;

    bool flipSprite = false;

    private void Update()
    {
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            flipSprite = true;
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            flipSprite = false;
        }

        playerSprite.flipX = flipSprite;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerAnimator.SetBool("isJumping", false);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        playerAnimator.SetBool("isJumping", true);
    }
}
