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
    [SerializeField] private float _speed, _baseMoveSpeed, _slowMoveSpeed;
    #endregion
    #region Properties
    public float Speed { get => _speed; }
    #endregion

    // Update is called once per frame
    void Update()
    {
        _directionToMove = _direction == Directions.Left ? Vector3.back : Vector3.forward;

        MoveObstacelAcrossStreet();
        MoveObstacleTowardsPlayer(_speed);

        _speed = PlayerBrake.instance.IsBraking ? _slowMoveSpeed : _baseMoveSpeed;
    }

    private void MoveObstacelAcrossStreet()
    {
        transform.Translate(_directionToMove * (2 * Time.deltaTime));
    }

    private void MoveObstacleTowardsPlayer(float speed)
    {
        transform.Translate(Vector3.right * (speed * Time.deltaTime));
    }

    private void OnEnable()
    {
        transform.position = ChooseSpawnLocation.instance.RandomSpawnLocation().position;
    }
}
