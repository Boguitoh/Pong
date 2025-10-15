using UnityEngine;

public class BallController : MonoBehaviour
{
    #region Variables

    private Rigidbody2D rb;
    public Vector2 startingVelocity = new Vector2(5f, 5f);
    public float speedUp = 1.05f;

    public GameManager gameManager;

    #endregion

    public void ResetBall()
    {
        transform.position = Vector3.zero;

        if (rb == null) rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = startingVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 newVelocity = rb.linearVelocity;

            newVelocity.y = -newVelocity.y;
            rb.linearVelocity = newVelocity;
        }

        if (collision.gameObject.CompareTag("Left") || collision.gameObject.CompareTag("Right"))
        {
            rb.linearVelocity = new Vector2(-rb.linearVelocityX, rb.linearVelocityY);
            rb.linearVelocity *= speedUp;
        }

        if (collision.gameObject.CompareTag("RightWall"))
        {
            gameManager.LeftPoint();
            ResetBall();
        }

        if (collision.gameObject.CompareTag("LeftWall"))
        {
            gameManager.RightPoint();
            ResetBall();
        }
    }
}
