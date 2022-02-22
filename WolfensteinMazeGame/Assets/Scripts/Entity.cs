using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private float _health = 10f;

    public void TakeDamage(float damageAmount)
    {
        _health -= damageAmount;
        if (_health <= 0f)
        {
            Defeat();
        }
    }

    private void Defeat()
    {
        Destroy(gameObject);
    }
}
