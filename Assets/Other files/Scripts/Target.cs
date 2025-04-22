using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
    public float maxHealth = 100f;
    public float respawnTime = 3f;
    public int scoreValue = 1; // 👈 Кол-во очков за уничтожение этой цели

    private float currentHealth;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    private Renderer[] renderers;
    private Collider[] colliders;

    private HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        initialPosition = transform.position;
        initialRotation = transform.rotation;

        renderers = GetComponentsInChildren<Renderer>();
        colliders = GetComponentsInChildren<Collider>();

        healthBar = GetComponentInChildren<HealthBar>();
        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth, maxHealth);
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        Debug.Log("Урон: " + amount + ", осталось: " + currentHealth);

        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth, maxHealth);
        }

        if (currentHealth <= 0f)
        {
            // 👉 Добавим очки
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddScore(scoreValue);
            }

            StartCoroutine(RespawnRoutine());
        }
    }

    IEnumerator RespawnRoutine()
    {
        DisableTarget();
        Debug.Log(gameObject.name + " уничтожен, возродится через " + respawnTime + " сек");

        yield return new WaitForSeconds(respawnTime);

        Respawn();
    }

    void DisableTarget()
    {
        foreach (var r in renderers) r.enabled = false;
        foreach (var c in colliders) c.enabled = false;

        if (healthBar != null)
        {
            healthBar.gameObject.SetActive(false);
        }
    }

    void Respawn()
    {
        transform.position = initialPosition;
        transform.rotation = initialRotation;
        currentHealth = maxHealth;

        foreach (var r in renderers) r.enabled = true;
        foreach (var c in colliders) c.enabled = true;

        if (healthBar != null)
        {
            healthBar.gameObject.SetActive(true);
            healthBar.SetHealth(currentHealth, maxHealth);
        }

        Debug.Log(gameObject.name + " возродился!");
    }
}
