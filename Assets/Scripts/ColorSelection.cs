using UnityEngine;
using UnityEngine.UI;

public class ColorSelection : MonoBehaviour
{
    #region VARIABLES
    public Button uiButton;
    public Image paddleReference;

    public bool isColorPlayer = false;
    #endregion

    public void OnButtonClick()
    {
        paddleReference.color = uiButton.colors.normalColor;

        if (isColorPlayer)
        {
            SaveController.instance.colorLeft = paddleReference.color;
        }
        else
        {
            SaveController.instance.colorRight = paddleReference.color;
        }
    }
}
