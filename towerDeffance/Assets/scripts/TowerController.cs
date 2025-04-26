using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TowerController : MonoBehaviour
{
    [Header("Tower Settings")]
    [SerializeField] private float range = 3f; // ��������� �����
    [SerializeField] private float fireRate = 1f; // �������� �������� (��������� � �������)
    [SerializeField] private int damage = 1; // ���� �� �������
    [SerializeField] private float turnSpeed = 10f; // �������� �������� �����

    [SerializeField] private GameObject projectilePrefab; // ������ �������
    private Transform firePoint; // ����� ������ �������
    [SerializeField] private float fireCountDown = 1f; // ������ ����� ����������

    [Header("Targeting")]
    public Transform target; // ������� ����

    void Start()
    {
        firePoint = transform.GetChild(0).transform;
        InvokeRepeating("UpdateTarget", 0, 0.5f);
    }

    void Update()
    {
        if (target == null)
            return;

        // ������� ����� � ������� ����
        Vector2 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed * Time.deltaTime);

        // �������� �� �������
        if (fireCountDown <= 0f)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }

        fireCountDown -= Time.deltaTime;
    }

    void UpdateTarget()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, range);
        float shortestDistance = Mathf.Infinity;

        foreach (Collider2D enemy in enemies)
        {
            if (enemy.TryGetComponent<EnemyController>(out EnemyController enemyController))
            {
                target = enemy.transform;
                break;
            }
            else
            {
                target = null;
            }
        }
    }

    // �������� �������
    void Shoot()
    {
        GameObject projectileGO = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
    }
}
