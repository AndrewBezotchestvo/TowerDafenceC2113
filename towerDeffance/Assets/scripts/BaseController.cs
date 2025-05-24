using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BaseController : MonoBehaviour
{
    [SerializeField] private float _health = 100f;
    [SerializeField] private float _radius = 3f;

    private void Update()
    {
        //Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, _radius);

        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, _radius);

        foreach (Collider2D enemy in enemies)
        {
            if (enemy.TryGetComponent<EnemyController>(out EnemyController enemyController))
            {
                _health -= enemyController.GetHealth();
                enemyController.GetDamage(enemyController.GetHealth());
            }
        }
    }

    public float GetHealth()
    {
        return _health;
    }

}
