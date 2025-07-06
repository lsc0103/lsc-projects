using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public UnityEvent onDeath;
    public UnityEvent<int> onHealthChanged;

    private int currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void Heal(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        onHealthChanged.Invoke(currentHealth);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        onHealthChanged.Invoke(currentHealth);
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            onDeath.Invoke();
        }
    }
}
