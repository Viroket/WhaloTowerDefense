using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;
    public Text scoreText;
    public GameObject exitButtonUI;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            scoreText.text = PlayerStats.CurrentScore().ToString();
            Toggle();
        }
    }

    public void ExitButtonPressed()
    {
        scoreText.text = PlayerStats.CurrentScore().ToString();
        Toggle();
    }

    private void OnEnable()
    {
        // scoreText.text = PlayerStats.CurrentScore().ToString();
    }

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

        if(ui.activeSelf)
        {
            exitButtonUI.SetActive(false);
            Time.timeScale = 0f;
        } else
        {
            exitButtonUI.SetActive(true);
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        Toggle();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Toggle();
        SceneManager.LoadScene(0);
    }
}
