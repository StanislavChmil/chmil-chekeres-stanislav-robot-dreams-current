using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealthUI : MonoBehaviour
{
    public Image hpFillImage;
    public TextMeshProUGUI hpText;

    public void UpdateHP(int currentHP, int maxHP)
    {
        float fillAmount = (float)currentHP / maxHP;
        hpFillImage.fillAmount = fillAmount;
        hpText.text = currentHP + " / " + maxHP;
    }
}