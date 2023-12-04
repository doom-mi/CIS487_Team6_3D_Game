using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemyPrefab;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    public Vector3 spawnPosition;
    public Quaternion spawnRotation;

    void Start()
    {
        countdown = timeBetweenWaves;
        
    }

    void Update()
    {
        if (state == SpawnState.WAITING) 
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (countdown <= 0f)
        {   
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
  
        }
        else
        {
            countdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        state = SpawnState.COUNTING;
        countdown = timeBetweenWaves;
        
        if (nextWave + 1 > waves.Length - 1)
        {
            //Put win condition or state here/Level finished scene here
            nextWave = 0;
            Debug.Log("Completed All Waves! Looping..");
        }
        else
        {
            nextWave++;
        }

    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                Debug.Log("Enemy Dead" + GameObject.FindGameObjectsWithTag("Enemy"));
                return false;
            }
        }
        Debug.Log("Enemy Alive" + GameObject.FindGameObjectsWithTag("Enemy"));
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;

        for (int i = 0; i <_wave.count; i++)
        {
            SpawnEnemy(_wave.enemyPrefab);
            yield return new WaitForSeconds( 1f/_wave.rate );
        }

        state   = SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("Spawning Enemy");
        Instantiate(_enemy, spawnPosition, spawnRotation);
    }

}
