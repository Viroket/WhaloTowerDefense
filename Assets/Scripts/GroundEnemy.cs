using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : MonoBehaviour
{
    public float speed = 1f;
    public float rotationSpeed = 5f;

    public int health = 30;

    public int value = 10;

    private Vector3 _target;
    public Board _board;
    private Vector3[] _points;
    private int _wavepointIndex = 0;
    // private Rigidbody _monsterRB;
    // Quaternion rotation;
    // Start is called before the first frame update

    public void SetSpeed()
    {
        speed += 2;
    }

    void Start()
    {
        _board = _board.GetComponent<Board>();
        if (gameObject.tag == "GroundEnemy")
        {
            _points = _board.GetGroundPath();
        } else
        {
            _points = _board.GetAirPath();
        }
            _target = _points[0];
        // _monsterRB = this.GetComponent<Rigidbody>();

    }

    public void TakeDamage(int amount)
    {
        if (gameObject.tag == "GroundEnemy")
        {
            health -= amount;
        } else
        {
            health = health - (amount * 2);
            Debug.Log(health);
        }
        if(health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        PlayerStats.playerState.AddScore(value);
        PlayerStats.playerState.AddFunds(value);
        Destroy(gameObject);

        WaveSpawner.EnemiesAlive--;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = _target - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        enemyLookDirection(dir);

        if (Vector3.Distance(transform.position, _target) <= 0.2f)
        {
            GetNextWayPoint();
        }
    }

    void enemyLookDirection(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        } else
        {
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }

    }

    void GetNextWayPoint()
    {
        if (_wavepointIndex >= _points.Length - 1)
        {
            EndPath();
            return;
        }
        _wavepointIndex++;
        _target = _points[_wavepointIndex];
    }


    void EndPath ()
    {
        PlayerStats.TakeDamage();
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
