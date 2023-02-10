using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerBrake))]
public class SetSpeed : MonoBehaviour
{
    public static SetSpeed instance;

    #region Variables
    [SerializeField] private float _speed, _baseSpeed, _slowSpeed;
    private PlayerBrake _playerBrake;
    #endregion
    #region Properties
    public float Speed { get => _speed; }
    #endregion

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        _playerBrake = GetComponent<PlayerBrake>();
    }

    // Update is called once per frame
    void Update()
    {
        AdjustSpeed();
    }

    private void AdjustSpeed()
    {
        _speed = _playerBrake.IsBraking ? _slowSpeed : _baseSpeed;
    }
}
