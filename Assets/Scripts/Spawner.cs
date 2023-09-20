using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Enemy _enemyTemplate;


    public void SpawnEnemy()
    {
        float shiftPositionY = Random.Range(-0.5f, 0.5f);
        Vector3 enemyPosition = new Vector3(transform.position.x,
            transform.position.y + shiftPositionY,
            transform.position.z);

        var enemy = Instantiate(_enemyTemplate, enemyPosition, Quaternion.identity);
        enemy.Init(_target);
        enemy.transform.SetParent(transform);
    }
}
