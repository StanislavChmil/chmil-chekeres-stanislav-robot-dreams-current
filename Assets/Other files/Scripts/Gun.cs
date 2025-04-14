using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Настройки")]
    public Transform muzzlePoint;             // Точка, откуда вылетает пуля
    public GameObject bulletPrefab;           // Слот для выбора пули
    public float bulletForce = 1000f;         // Сила выстрела

    Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))      // ЛКМ
        {
            Fire();
        }
    }

    void Fire()
    {
        if (bulletPrefab == null || muzzlePoint == null) return;

        // Создаём пулю
        GameObject bullet = Instantiate(bulletPrefab, muzzlePoint.position, Quaternion.identity);

        // Вычисляем направление в центр экрана
        Ray ray = mainCam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        Vector3 direction = ray.direction;

        // Применяем силу
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(direction * bulletForce);
        }
    }
}
