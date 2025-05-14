using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    void LateUpdate()
    {
        if (Camera.main == null) return;

        // Поворачиваем к камере только по горизонтали (если надо)
        Vector3 direction = Camera.main.transform.position - transform.position;
        direction.y = 0; // не наклоняться вверх/вниз
        transform.rotation = Quaternion.LookRotation(-direction);
    }
}