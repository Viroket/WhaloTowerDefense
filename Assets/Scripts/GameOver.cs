using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text scoreText;

    private void OnEnable()
    {
        scoreText.text = PlayerStats.CurrentScore().ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
