using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawnManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject _obstacleGO;
    [SerializeField] private float _timer;
    [SerializeField] private float _randomSpawnTime;
    [SerializeField] float _spawnMin, _spawnMax;
    #endregion

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.GameState == GameManager.GameStates.Play)
        {
            _timer += Time.deltaTime;

            SpawnObstacle();
        }
    }

    private void SpawnObstacle()
    {
        if(_timer >= _randomSpawnTime)
        {
            _timer = 0;
            Instantiate(_obstacleGO);
            _randomSpawnTime = Random.Range(_spawnMin, _spawnMin);
        }
    }
}
