using UnityEngine;

public class Damage : MonoBehaviour
{
    public float Health = 50f;

    public void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
