using UnityEngine.UI;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("SCORE " + PlayerStats.Score);
        scoreText.text = "SCORE " + PlayerStats.CurrentScore();
    }
}
