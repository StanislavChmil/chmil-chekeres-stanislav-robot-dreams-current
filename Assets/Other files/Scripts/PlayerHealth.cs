using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP;
    public PlayerHealthUI ui;

    void Start()
    {
        currentHP = maxHP;
        ui.UpdateHP(currentHP, maxHP); // Показываем начальное значение
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        ui.UpdateHP(currentHP, maxHP);

        if (currentHP <= 0)
        {
            Debug.Log("Player Died");
            // Добавь логику смерти, если нужно
        }
    }
}