using UnityEngine;

public class RPMovement : MonoBehaviour
{
    #region Variables

    public float speed;

    public string movementAxisName = "Vertical2";

    public bool isPlayer = true;
    public SpriteRenderer spriteRenderer;
    #endregion

    private void Start()
    {
        if (isPlayer)
            spriteRenderer.color = SaveController.instance.colorLeft;
        else
            spriteRenderer.color = SaveController.instance.colorRight;
    }

    private void Update()
    {
        // Registra tecla de movimento
        float moveInput = Input.GetAxis(movementAxisName);

        // Calcula posição baseado em comando
        Vector3 newPosition = transform.position + Vector3.up * moveInput * speed * Time.deltaTime;

        // Limita posição para não sair da tela
        newPosition.y = Mathf.Clamp(newPosition.y, -4.5f, 4.5f);

        // Move a raquete
        transform.position = newPosition;
    }



    /* MOVIMENTACAO AUTOMATICA
    private Rigidbody2D rb;
    public float speed;

    private GameObject ball;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ball = GameObject.Find("Ball");     // Busca a bola
    }

    void Update()
    {
        if (ball != null)
        {
            float targetY = Mathf.Clamp(ball.transform.position.y, -4.5f, 4.5f);    // Limita posY
            Vector2 targetPosition = new Vector2(transform.position.x, targetY);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);   // Se move ao posY da bola
        }
    }
    */
}
