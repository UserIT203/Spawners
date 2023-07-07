using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemyTemplate;
    [SerializeField] private float _timeToSpawn;

    private Transform[] _spawners;
    private bool _isSpawn;

    private void Start()
    {
        _spawners = new Transform[transform.childCount];
        _isSpawn = true;

        for (int i = 0; i < transform.childCount; i++)
        {
            _spawners[i] = transform.GetChild(i);
        }

        StartCoroutine(Spawn());
    }

    private void CreateEnemy(int spawnerIndex)
    {
        float shiftPositionY = Random.Range(-0.5f, 0.5f);
        Vector3 enemyPosition = new Vector3(_spawners[spawnerIndex].position.x, 
            _spawners[spawnerIndex].position.y + shiftPositionY, 
            _spawners[spawnerIndex].position.z);

        var enemy = Instantiate(_enemyTemplate, enemyPosition, Quaternion.identity);
        enemy.transform.SetParent(_spawners[spawnerIndex]);
    }

    private IEnumerator Spawn()
    {
        int currentSpawnerIndex = 0;
        var waitForSpawnTimeSecond = new WaitForSeconds(_timeToSpawn);

        while (_isSpawn)
        {
            CreateEnemy(currentSpawnerIndex);

            yield return waitForSpawnTimeSecond;

            currentSpawnerIndex++;

            if (currentSpawnerIndex >= _spawners.Length)
                currentSpawnerIndex = 0;
        }
    }
}
