using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTurret : MonoBehaviour
{
    [Header("Attributes")]
    private Transform _target;
    public float range = 4f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]
    public string enemyTag = "GroundEnemy";
    public float turnSpeed = 15f;
    public Transform partToRotate;

    public GameObject groundBulletPre;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarger", 0f, 0.5f);
    }

    void UpdateTarger()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity; // start with no target
        GameObject nearestEnemy = null;
        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position); // returen the distance between torret and enemy
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            _target = nearestEnemy.transform;
        } else
        {
            _target = null;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (_target == null)
            return;

        // Target Lock on
        Vector3 dir = _target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(-90f, rotation.y, 0f);

        // fire
        if (fireCountdown <= 0)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(groundBulletPre, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(_target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
