using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] wayPoints; // Массив трансформов точек, по которым идет враг

    private void Awake()
    {
        wayPoints = new Transform[transform.childCount]; // Создаем новый массив с числом int кол-ва чайлдов в объекте
        // Проходим по массиву точек
        for (int i = 0; i < wayPoints.Length; i++)
        {
            wayPoints[i] = transform.GetChild(i); // Запушиваем их в массив
        }
    }
}
