using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;

    public float speed = 20f;
    public int Grounddamage = 10;
    public int Airdamage = 20;

    public GameObject impactEffect;

    public void Seek(Transform _target)
    {
        target = _target;   
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame) // whenever we hit the target
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2);
        Destroy(gameObject);

        Damage(target);
    }

    void Damage(Transform enemy)
    {
        GroundEnemy e = enemy.GetComponent<GroundEnemy>();
        if (e != null)
        {
            if (e.tag == "GroundEnemy")
            {
                e.TakeDamage(Grounddamage);
            } else
            {
                e.TakeDamage(Airdamage);
            }
        }
    }
}
