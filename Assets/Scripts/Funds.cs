using UnityEngine;
using UnityEngine.UI;

public class Funds : MonoBehaviour
{
    public Text fundsText;
    // Update is called once per frame
    void Update()
    {
        fundsText.text = "FUNDS " + PlayerStats.playerState.Funds.ToString();
    }
}
