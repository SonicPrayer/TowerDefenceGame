using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIMovement : MonoBehaviour
{
    public float enemySpeed = 5f; // Скорость врага

    private Transform target; // Положение врага
    private int wavepointIndex = 0; // Начальная позиция

    private void Start()
    {
        target = Waypoints.wayPoints[0]; // Даем проложению врага трансформ первой точки из массива всех точек
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemySpeed * Time.deltaTime, Space.World); // Идем дальше

        // Пока не достигнем следующей точки
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint(); // Идем в следующую точку
        }
    }

    private void GetNextWaypoint()
    {
        // Если это последняя точка
        if (wavepointIndex >= Waypoints.wayPoints.Length - 1)
        {
            Destroy(gameObject); // Уничтожить врага
            return;
        }

        wavepointIndex++; // Берем идекс следующей точки
        target = Waypoints.wayPoints[wavepointIndex]; // Идем в эту точку
    }
}
