using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrake : MonoBehaviour
{
    public static PlayerBrake instance;

    #region Variables
    [SerializeField] private bool _isBraking, _canBrake;
    [SerializeField] private float _brakeTime;
    [SerializeField] private float _maximumBrakeAllowance;
    #endregion
    #region Properties
    public bool IsBraking { get => _isBraking; }
    public float BrakeTime { get => _brakeTime; }
    public float MaximumBrakeAllowance { get => _maximumBrakeAllowance; }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        ApplyBrakes();
        AdjustTimer(_isBraking);
    }

    private void ApplyBrakes()
    {
        if(_brakeTime > 0 && _canBrake)
        {
            // Sets the isBraking bool when the players presses and holds the space bar && brakeTime is greater than 0 
            _isBraking = (Input.GetKey(KeyCode.Space)) ? true : false;
        }
        else if(_brakeTime <= 0)
        {
            _canBrake = false;
            _isBraking = false;
        }
        else if(!_canBrake && _brakeTime >= _maximumBrakeAllowance)
        {
            _canBrake = true;
        }
    }

    private void AdjustTimer(bool isBraking)
    {
        // Creates a temp variable adjustment that is used to adjust the timer based on whether the player isBraking
        int adjustment = isBraking == true ? -1 : 1;
        // Adjusts brakeTime based on adjustment variable and deltaTime
        _brakeTime += (adjustment * Time.deltaTime);
        // Limits brakeTime so if the value goes beyond the maximum allowance it reverts back to the value of maximum allowance
        // The same is done for if the value goes below 0. Setting it to 0
        _brakeTime = (_brakeTime >= _maximumBrakeAllowance) ? _maximumBrakeAllowance : (_brakeTime <= 0) ? 0 : _brakeTime;
    }
}
