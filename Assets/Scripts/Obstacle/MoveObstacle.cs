using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    public enum Directions
    {
        Left, Right
    }

    #region Variables
    [SerializeField] private Directions _direction;
    [SerializeField] private Vector3 _directionToMove;
    [SerializeField] private float _moveAcrossStreetSpeed = 2;
    [SerializeField] private float _speed;
    [SerializeField] [Range(1, 5)] private int _speedFilter = 2;
    #endregion
    #region Properties
    public float Speed { get => _speed; }
    #endregion

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.GameState == GameManager.GameStates.Play)
        {
            _speed = SetSpeed.instance.Speed * _speedFilter;
            MoveObstacelAcrossStreet();
            MoveObstacleTowardsPlayer(_speed);
        }
    }

    private void MoveObstacelAcrossStreet()
    {
        transform.Translate(_directionToMove * (_moveAcrossStreetSpeed * Time.deltaTime));
    }

    private void MoveObstacleTowardsPlayer(float speed)
    {
        transform.Translate(Vector3.right * (speed * Time.deltaTime));
    }

    private void OnEnable()
    {
        _moveAcrossStreetSpeed = Random.Range(1, 4);
        transform.position = ChooseSpawnLocation.instance.RandomSpawnLocation().position;
        _direction = ChooseSpawnLocation.instance.ReturnRandomSpawnLocation() == 0 ? Directions.Right : Directions.Left;
        _directionToMove = _direction == Directions.Left ? Vector3.back : Vector3.forward;
    }
}
