using TMPro;
using UnityEngine;

public class PowerUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI powerText;


    private void OnEnable()
    {
        Player.Instance.OnPowerChanged += UpdatePowerText;
    }

    private void UpdatePowerText(float power)
    {
        powerText.text = " Power : " + power.ToString("F1");
    }

    private void OnDisable()
    {
        if (Player.Instance != null)
            Player.Instance.OnPowerChanged -= UpdatePowerText;
        powerText.text = "";
    }
}
