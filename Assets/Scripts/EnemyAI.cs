using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    public int maxHealth = 50;
    public int damage = 10;
    public float attackDistance = 2f;
    public float attackRate = 1f;
    public Renderer hitRenderer;

    private int currentHealth;
    private NavMeshAgent agent;
    private float attackTimer;
    private Color originalColor;

    void Awake()
    {
        currentHealth = maxHealth;
        agent = GetComponent<NavMeshAgent>();
        if (hitRenderer)
            originalColor = hitRenderer.material.color;
    }

    void Update()
    {
        if (!GameManager.Instance || !GameManager.Instance.player)
            return;

        agent.SetDestination(GameManager.Instance.player.position);

        float distance = Vector3.Distance(transform.position, GameManager.Instance.player.position);
        attackTimer -= Time.deltaTime;
        if (distance <= attackDistance && attackTimer <= 0f)
        {
            Attack();
            attackTimer = attackRate;
        }
    }

    void Attack()
    {
        PlayerHealth ph = GameManager.Instance.player.GetComponent<PlayerHealth>();
        if (ph)
        {
            ph.TakeDamage(damage);
        }
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (hitRenderer)
        {
            hitRenderer.material.color = Color.red;
            Invoke(nameof(ResetColor), 0.1f);
        }
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void ResetColor()
    {
        if (hitRenderer)
        {
            hitRenderer.material.color = originalColor;
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
