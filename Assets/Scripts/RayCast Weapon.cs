using UnityEngine;
using System.Collections;

public class RayCastWeapon : MonoBehaviour
{
    public float range = 100f;
    public float damage = 10f;
    public Transform muzzlePoint;

    public GameObject muzzleFlashPrefab;
    public GameObject explosionEffectPrefab;
    public GameObject volumetricLaserPrefab; // Префаб с VolumetricLineBehavior

    public float explosionRadius = 8f;
    public float explosionForce = 1500f;

    private Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FireRay();
        }

        if (Input.GetMouseButtonDown(1))
        {
            FireExplosionRay();
        }
    }

    void FireRay()
    {
        if (muzzleFlashPrefab)
        {
            GameObject flash = Instantiate(muzzleFlashPrefab, muzzlePoint.position, muzzlePoint.rotation);
            Destroy(flash, 0.05f);
        }

        Ray ray = mainCam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        Vector3 hitPoint = ray.origin + ray.direction * range;

        if (Physics.Raycast(ray, out hit, range))
        {
            hitPoint = hit.point;

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }

        // Визуальный объёмный лазер
        if (volumetricLaserPrefab != null)
        {
            GameObject laser = Instantiate(volumetricLaserPrefab);
            laser.transform.position = muzzlePoint.position;

            var laserComp = laser.GetComponent<VolumetricLines.VolumetricLineBehavior>();
            if (laserComp != null)
            {
                laserComp.StartPos = Vector3.zero;
                laserComp.EndPos = muzzlePoint.InverseTransformPoint(hitPoint);
            }

            Destroy(laser, 0.05f);
        }
    }

    void FireExplosionRay()
    {
        Ray ray = mainCam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range))
        {
            Vector3 explosionPoint = hit.point;

            if (explosionEffectPrefab)
            {
                GameObject explosion = Instantiate(explosionEffectPrefab, explosionPoint, Quaternion.identity);
                Destroy(explosion, 2f);
            }

            Collider[] colliders = Physics.OverlapSphere(explosionPoint, explosionRadius);
            foreach (Collider nearby in colliders)
            {
                Rigidbody rb = nearby.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(explosionForce, explosionPoint, explosionRadius);
                }
            }

            Debug.Log("Взрыв в точке попадания: " + explosionPoint);
        }
    }
}
