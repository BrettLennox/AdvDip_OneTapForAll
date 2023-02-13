using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Timer))]
public class ObstacleSpawnManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject _obstacleGO;
    [SerializeField] private float _randomSpawnTime;
    [SerializeField] float _spawnMin, _spawnMax;
    #endregion

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.GameState == GameManager.GameStates.Play)
        {
            SpawnObstacle();
        }
    }

    private void SpawnObstacle()
    {
        if(Timer.instance.Counter >= _randomSpawnTime)
        {
            Timer.instance.Counter = 0;
            Instantiate(_obstacleGO);
            _randomSpawnTime = Random.Range(_spawnMin, _spawnMin);
        }
    }
}
