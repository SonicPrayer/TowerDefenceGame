using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab; // Префаб врага
    public float timeBetweenWaves = 5f; // Время между спауном волн
    public Transform spawnPoint; // Точка спауна врага
    public float waitSecond = 0.2f; // Задержка перед спауном
    public Text waveCountdownText;  // Текст отсчета спауна

    private float countdown = 5f; // Задержка перед спауном первой волны
    private int waveNumber = 1; // Кол-во врагов в волне

    private void Update()
    {
        // Если таймер опустился до 0
        if (countdown <=0)
        {
            StartCoroutine(SpawnWave()); // Спауним волну
            countdown = timeBetweenWaves; // Добавляем время к следующему спауну
        }

        countdown -= Time.deltaTime; // Отсчет таймера(уменьшаем)
        waveCountdownText.text = Mathf.Round(countdown).ToString(); // Выводим в текст время до следующей волны

    }

    // Метод спауна волны
    IEnumerator SpawnWave()
    {
        waveNumber++; // Следующая волна
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy(); // Спауним врагов
            yield return new WaitForSeconds(waitSecond);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation); // Создаем врага путем копирования в точке
    }
}
