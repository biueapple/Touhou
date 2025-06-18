using TMPro;
using UnityEngine;

public class LifeUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI lifeText;


    private void OnEnable()
    {
        Player.Instance.OnLifeChanged += UpdateLifeText;
    }

    private void UpdateLifeText(int life)
    {
        lifeText.text = " Life : " + life;
    }

    private void OnDisable()
    {
        Player.Instance.OnLifeChanged -= UpdateLifeText;
        lifeText.text = "";
    }
}
