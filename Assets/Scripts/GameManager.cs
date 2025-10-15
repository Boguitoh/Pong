using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    #region Variables

    public Transform leftPaddle;
    public Transform rightPaddle;

    public int leftScore = 0;
    public int rightScore = 0;
    public TextMeshProUGUI textLeftScore;
    public TextMeshProUGUI textRightScore;

    public int winScore;

    public BallController ballController;

    public GameObject endGameScreen;
    public TextMeshProUGUI textEndGame;
    #endregion

    private void Start()
    {
        ResetGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetGame();
        }
    }

    public void ResetGame()
    {
        leftPaddle.position = new Vector3(-7f, 0f, 0f);
        rightPaddle.position = new Vector3(7f, 0f, 0f);

        ballController.ResetBall();

        leftScore = 0;
        rightScore = 0;
        textLeftScore.text = leftScore.ToString();
        textRightScore.text = rightScore.ToString();

        endGameScreen.SetActive(false);
    }

    public void LeftPoint()
    {
        leftScore++;
        textLeftScore.text = leftScore.ToString();
        CheckWin();
    }

    public void RightPoint()
    {
        rightScore++;
        textRightScore.text = rightScore.ToString();
        CheckWin();
    }

    public void CheckWin()
    {
        if (rightScore >= winScore || leftScore >= winScore)
        {
            //ResetGame();
            EndGame();
        }
    }

    public void EndGame()
    {
        endGameScreen.SetActive(true);
        //textEndGame.text = "Vitória de " + SaveController.instance.GetName(leftScore > rightScore);
        string winner = SaveController.instance.GetName(leftScore > rightScore);
        textEndGame.text = "Vitória de " + winner;
        SaveController.instance.SaveWinner(winner);

        Invoke("LoadMenu", 2f);
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
