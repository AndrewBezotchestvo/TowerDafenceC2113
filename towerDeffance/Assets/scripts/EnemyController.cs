using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private List<GameObject> waypoints; // ������ ����� ��� �����������
    [SerializeField] private float moveSpeed = 3f; // �������� �����������
    [SerializeField] private float reachThreshold = 0.1f; // ����������, �� ������� ����� ��������� �����������
    [SerializeField] private float health = 100;

    private int currentWaypointIndex = 0;
    private bool isMoving = true;

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if (!isMoving || waypoints.Count == 0) return;

        // �������� ������� ������� �����
        Vector2 target = waypoints[currentWaypointIndex].transform.position;

        // ���������� ��������� � �����
        transform.position = Vector2.MoveTowards(
            transform.position,
            target,
            moveSpeed * Time.deltaTime
        );

        // ���������, �������� �� �� �����
        if (Vector2.Distance(transform.position, target) < reachThreshold)
        {
            // ������������� �� ��������� �����
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;

            // ���� �����, ����� �������� ����������� ����� ��������� �����:
            if (currentWaypointIndex == 0) isMoving = false;
        }
    }

    // ����� ��� �������/��������� ��������
    public void SetMovement(bool shouldMove)
    {
        isMoving = shouldMove;
    }

    public void GetDamage(float damage)
    {
        health -= damage;
    }
}
