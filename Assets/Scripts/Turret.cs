using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target; // Враг
    public float range = 15f; // Расстояние до врага
    public string enemyTag = "Enemy"; // Тег для поиска врага

    public Transform partToRotate; // Какую часть турели поворачиваем
    public float turnSpeed = 10f; // Скорость поворота

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    // Метод для обновления таргета
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag); // Создаем массив со всеми врагами на сцене по тегу
        float shortestDistance = Mathf.Infinity; // Значение кратчайшего расстояния до врага
        GameObject nearestEnemy = null; // Объект ближайшего врага

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position); // Получаем значение расстояния до врага
            // Если расстояние от турели до врага меньше кратчайшего расстояния
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy; // Кратчайшее растояние есть растояние до врага
                nearestEnemy = enemy; // Ближайший враг
            }
        }

        // Если враг есть и кратчайшее расстояние меньше или равно расстоянию до врага
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform; // Установить таргет на врага
        } else
        {
            target = null;
        }

    }

    void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 dir = target.position - transform.position; // Получаем вектор направления на врага
        Quaternion lookRotation = Quaternion.LookRotation(dir); // Как повернуть турель в направлении врага
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles; // Конвертируем в поворот в систему трех координат
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f); // Делаем поворот турели
    }

    // Метод для отрисовки радиуса турели
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
