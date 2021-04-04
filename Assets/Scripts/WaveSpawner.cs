using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;

    public Wave[] waves;

    public Transform _groundSpawnPoint;
    public Transform _airSpawnPoint;

    public float _timeBetweenWaves = 10f;
    private float _countdown = 10f;

    public Text waveCountDownText;

    public static int waveIndex = 0;
    public static int waveIndexCount = 0;


    void Update()
    {
        if (EnemiesAlive > 0)
        {
            return;
        }
        if (_countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            _countdown = _timeBetweenWaves;
            return;
        }

        _countdown -= Time.deltaTime; //  Reduce countdown 1 every second

        _countdown = Mathf.Clamp(_countdown, 0f, Mathf.Infinity);
        waveCountDownText.text = Mathf.Round(_countdown).ToString();

    }

    IEnumerator SpawnWave()
    {
        Wave wave = waves[waveIndex];
        if (wave.countAir > 0)
        {
            for (int i = 0; i < wave.countAir; i++)
            {
                SpawnEnemy(wave.enemyAir);
                yield return new WaitForSeconds(2f);
            }
        }
        for (int i = 0; i < wave.countGround; i++)
        {
            SpawnEnemy(wave.enemyGround);
            yield return new WaitForSeconds(2f);
        }

        // wave.count = wave.count * 2;
        if (wave.enemyGround)
        {
            GroundEnemy enemy = wave.enemyGround.GetComponent<GroundEnemy>();
            enemy.health += 20;
            enemy.speed++;
        } else
        {
            GroundEnemy enemy = wave.enemyGround.GetComponent<GroundEnemy>();
            enemy.health += 20;
            enemy.speed++;
        }
        waveIndex++;
    }

    public void ChangeEnemyStats()
    {
        if(waveIndexCount == waveIndex)
        {
         
        } else
        {
            waveIndexCount = waveIndex;
        }
    }

    void SpawnEnemy (GameObject enemy)
    {
        if (enemy.tag == "GroundEnemy")
        {
            Instantiate(enemy, _groundSpawnPoint.position, _groundSpawnPoint.rotation);
        } else
        {
            Instantiate(enemy, _airSpawnPoint.position, _groundSpawnPoint.rotation);
        }
       
        EnemiesAlive++;
    }
}
