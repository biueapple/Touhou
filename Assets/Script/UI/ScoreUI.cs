using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;


    private void OnEnable()
    {
        ScoreManager.Instance.OnScoreChanged += UpdateScoreText;
    }

    private void UpdateScoreText(uint score)
    {
        scoreText.text = " Score : " + score;
    }

    private void OnDisable()
    {
        ScoreManager.Instance.OnScoreChanged -= UpdateScoreText;
        scoreText.text = "";
    }
}
