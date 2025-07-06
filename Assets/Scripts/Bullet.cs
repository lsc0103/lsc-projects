using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 20;
    public float lifeTime = 2f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        EnemyAI enemy = other.GetComponent<EnemyAI>();
        if (enemy)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
