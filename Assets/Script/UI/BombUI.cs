using TMPro;
using UnityEngine;

public class BombUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI bombText;


    private void OnEnable()
    {
        Player.Instance.OnBombChanged += UpdateBombText;
    }

    private void UpdateBombText(int bomb)
    {
        bombText.text = " Bomb : " + bomb;
    }

    private void OnDisable()
    {
        if (Player.Instance != null)
            Player.Instance.OnBombChanged -= UpdateBombText;
        bombText.text = "";
    }
}
