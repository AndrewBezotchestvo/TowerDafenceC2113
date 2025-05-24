using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private List<GameObject> waypoints; // Список точек для перемещения
    [SerializeField] private float moveSpeed = 3f; // Скорость перемещения
    [SerializeField] private float reachThreshold = 0.1f; // Расстояние, на котором точка считается достигнутой
    [SerializeField] private float health = 100;
    [SerializeField] private GameController _gameController;

    private int currentWaypointIndex = 0;
    private bool isMoving = true;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (health <= 0 && isMoving)
        {
            _gameController.TakeMoney(5);
            _animator.SetBool("death", true);
            isMoving = false;
            Invoke("EnemyDestroy", 3);
        }

        if (!isMoving || waypoints.Count == 0) return;

        // Получаем текущую целевую точку
        Vector2 target = waypoints[currentWaypointIndex].transform.position;

        // Перемещаем персонажа к точке
        transform.position = Vector2.MoveTowards(
            transform.position,
            target,
            moveSpeed * Time.deltaTime
        );

        // Проверяем, достигли ли мы точки
        if (Vector2.Distance(transform.position, target) < reachThreshold)
        {
            // Переключаемся на следующую точку
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;

            // Если хотим, чтобы персонаж остановился после последней точки:
            if (currentWaypointIndex == 0) isMoving = false;
        }
    }

    // Метод для запуска/остановки движения
    public void SetMovement(bool shouldMove)
    {
        isMoving = shouldMove;
    }

    public void GetDamage(float damage)
    {
        if (isMoving)
        {
            health -= damage;
            _animator.SetTrigger("heart");
        }
    }

    public void EnemyDestroy()
    {
        Destroy(gameObject);
    }

    public float GetHealth()
    { 
        return health; 
    }
}
