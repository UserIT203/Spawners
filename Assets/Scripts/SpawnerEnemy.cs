using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private Enemy _enemyTemplate;
    [SerializeField] private float _timeToSpawn;

    private Spawner[] _spawners;
    private bool _isSpawn;

    private void Start()
    {
        _spawners = new Spawner[transform.childCount];
        _isSpawn = true;

        for (int i = 0; i < transform.childCount; i++)
        {
            _spawners[i] = transform.GetChild(i).GetComponent<Spawner>();
        }

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        int currentSpawnerIndex = 0;
        var waitForSpawnTimeSecond = new WaitForSeconds(_timeToSpawn);

        while (_isSpawn)
        {
            _spawners[currentSpawnerIndex].SpawnEnemy();

            yield return waitForSpawnTimeSecond;

            currentSpawnerIndex++;

            if (currentSpawnerIndex >= _spawners.Length)
                currentSpawnerIndex = 0;
        }
    }
}
