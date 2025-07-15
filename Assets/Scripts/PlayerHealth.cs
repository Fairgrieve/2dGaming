using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    public int CurrentHealth { get; private set; }

    void Awake() => CurrentHealth = maxHealth;

    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
        Debug.Log($"Player took {amount} damage. HP: {CurrentHealth}");
        if (CurrentHealth <= 0) Die();
    }

    void Die()
    {
        Debug.Log("D:");
        // TODO: respawn, game‑over UI, etc. future Jon issues
    }
}
