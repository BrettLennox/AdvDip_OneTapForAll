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
    [SerializeField] private int _buttonPresses;
    [SerializeField] private float _buttonPressTimer = 0;
    [SerializeField] private float _boostDuration;
    private float _boostTimer;
    [SerializeField] private bool _boosting;
    #endregion
    #region Properties
    public bool IsBraking { get => _isBraking; }
    public float BrakeTime { get => _brakeTime; }
    public float MaximumBrakeAllowance { get => _maximumBrakeAllowance; }
    public bool IsBoosting { get => _boosting; }
    #endregion

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        ApplyBrakes();
        AdjustTimer(_isBraking);

        if (_buttonPresses > 0)
        {
            _buttonPressTimer += Time.deltaTime;
            if (_buttonPressTimer >= 1f)
            {
                _buttonPresses = 0;
                _buttonPressTimer = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && !_boosting)
        {
            _buttonPresses++;
        }

        if (_buttonPresses >= 2)
        {
            Debug.Log("BOOSTING");
            _boosting = true;
            _buttonPresses = 0;
            _buttonPressTimer = 0;
        }

        if (_boosting)
        {
            _boostTimer += Time.deltaTime;
        }

        if (_boostTimer >= _boostDuration)
        {
            _boosting = false;
            _boostTimer = 0;
            _brakeTime = _maximumBrakeAllowance;
        }
    }

    private void ApplyBrakes()
    {
        if (_brakeTime > 0 && _canBrake)
        {
            // Sets the isBraking bool when the players presses and holds the space bar && brakeTime is greater than 0 
            _isBraking = (Input.GetKey(KeyCode.Space)) ? true : false;
        }
        else if (_brakeTime <= 0)
        {
            _canBrake = false;
            _isBraking = false;
        }
        else if (!_canBrake && _brakeTime >= _maximumBrakeAllowance)
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
