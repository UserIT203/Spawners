using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemyTemplate;
    [SerializeField] private float _timeToSpawn;

    private float _currentTimeToSpawn;
    private Transform[] _spawners;
    private int _currentSpawnerIndex;

    private void Start()
    {
        _spawners = new Transform[transform.childCount];
        _currentTimeToSpawn = 0;

        for (int i = 0; i < transform.childCount; i++)
        {
            _spawners[i] = transform.GetChild(i);
        }
    }

    private void CreateEnemy(int spawnerIndex)
    {
        float shiftPositionY = Random.Range(-0.5f, 0.5f);
        Vector3 enemyPosition = new Vector3(_spawners[spawnerIndex].position.x, _spawners[spawnerIndex].position.y + shiftPositionY, 
            _spawners[spawnerIndex].position.z);

        var enemy = Instantiate(_enemyTemplate, enemyPosition, Quaternion.identity);
        enemy.transform.SetParent(_spawners[spawnerIndex]);
    }

    private void Update()
    {
        _currentTimeToSpawn += Time.deltaTime;

        if(_currentTimeToSpawn >= _timeToSpawn)
        {
            _currentTimeToSpawn = 0;

            if (_currentSpawnerIndex >= _spawners.Length)
                _currentSpawnerIndex = 0;

            CreateEnemy(_currentSpawnerIndex);
            _currentSpawnerIndex++;
        }
    }
}
