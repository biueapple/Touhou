using TMPro;
using UnityEngine;

public class BombUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI bombText;


    private void OnEnable()
    {
        Player.Instance.OnBombChanged += UpdateScoreText;
    }

    private void UpdateScoreText(int bomb)
    {
        bombText.text = " Bomb : " + bomb;
    }

    private void OnDisable()
    {
        Player.Instance.OnBombChanged -= UpdateScoreText;
        bombText.text = "";
    }
}
