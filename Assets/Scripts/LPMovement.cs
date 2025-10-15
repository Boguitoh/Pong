using UnityEngine;

public class LPMovement : MonoBehaviour
{
    #region Variables

    public float speed;

    public string movementAxisName = "Vertical";

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
}
