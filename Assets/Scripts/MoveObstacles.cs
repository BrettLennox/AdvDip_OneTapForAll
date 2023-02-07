using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacles : MonoBehaviour
{
    #region Variables
    [SerializeField] private float _speed, _baseMoveSpeed, _slowMoveSpeed;
    #endregion
    #region Properties
    public float Speed { get => _speed; }
    #endregion

    // Update is called once per frame
    void Update()
    {
        MoveObstacle(_speed);

        _speed = PlayerBrake.instance.IsBraking ? _slowMoveSpeed : _baseMoveSpeed;
    }

    private void MoveObstacle(float speed)
    {
        transform.Translate(Vector3.right * (speed * Time.deltaTime));
    }
}
