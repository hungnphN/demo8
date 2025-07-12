using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyWave[] enemyWaves;
    private int currentWave;
    public Transform bossPrefab;
    public FlyPath bossFlyPath;
    public float bossSpeed = 2f;
    public float delayBeforeBoss = 2f;


    // Start is called before the first frame update
    void Start()
    {
        //SpawnEnemyWave();
        StartCoroutine(spawnWavesthenBoss());
    }
    IEnumerator spawnWavesthenBoss()
    {
        while (currentWave < enemyWaves.Length)
        {
            SpawnEnemyWave();
            float delay = enemyWaves[currentWave].nextWaveDelay;
            currentWave++;
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(delayBeforeBoss);
        SpawnBoss();
    }
    private void SpawnEnemyWave()
    {
        var waveInfo = enemyWaves[currentWave];
        var startPosition = waveInfo.flyPath[0];
        for (int i = 0; i < waveInfo.numberOfEnemy; i++)
        {
            var enemy = Instantiate(waveInfo.enemyPrefab, startPosition, Quaternion.identity);
            var agent = enemy.GetComponent<FlyPathArgent>();
            agent.flyPath = waveInfo.flyPath;
            agent.flySpeed = waveInfo.speed;
            startPosition += waveInfo.formationOffset;
            agent.isReady = true;
            startPosition += waveInfo.formationOffset;
        }
        //currentWave++;
        //if(currentWave < enemyWaves.Length)
        //{
        //    Invoke(nameof(SpawnEnemyWave), waveInfo.nextWaveDelay);
        //}
    }
    private void SpawnBoss()
    {
        if (bossPrefab == null || bossFlyPath == null)
        {
            Debug.LogWarning("Boss Prefab or flypath chua doc gan!");
            return;
        }
        Vector3 startPos = bossFlyPath.waypoints[0].transform.position;
        var boss = Instantiate(bossPrefab, startPos, Quaternion.identity);
        var agent = boss.GetComponent<FlyPathArgent>();
        agent.flyPath = bossFlyPath;
        agent.flySpeed = bossSpeed;
        agent.isReady = true;
        Debug.Log("Boss Spawned");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
