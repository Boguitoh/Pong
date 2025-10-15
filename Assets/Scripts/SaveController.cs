using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour
{
    public Color colorLeft = Color.white;
    public Color colorRight = Color.white;

    private static SaveController _instance;

    public string nameLeft;
    public string nameRight;

    //Propriedade para acessar instancia
    public static SaveController instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindFirstObjectByType<SaveController>();

                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(SaveController).Name);
                    _instance = singletonObject.AddComponent<SaveController>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        // Garante que apenas uma instancia do singleton exista
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        // Manter singleton entre cenas
        DontDestroyOnLoad(this.gameObject);
    }

    public string GetName(bool isPlayer)
    {
        return isPlayer ? nameLeft : nameRight;
    }

    public void Reset()
    {
        nameLeft = "";
        nameRight = "";
        colorLeft = Color.white;
        colorRight = Color.white;
    }

    public void SaveWinner(string winner)
    {
        PlayerPrefs.SetString("SavedWinner", winner);
    }

    public string GetLastWinner()
    {
        return PlayerPrefs.GetString("SavedWinner");
    }

    public void ClearSave()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
