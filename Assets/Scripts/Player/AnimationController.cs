using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    #region Variables
    [SerializeField] private Animator _anim;
    [SerializeField] private PlayerBrake _playerBrake;
    #endregion

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _playerBrake = GetComponentInParent<PlayerBrake>();
    }

    private void Update()
    {
        _anim.SetBool("IsBraking", _playerBrake.IsBraking);
    }

    public void StartBrakeEventReached()
    {
        _anim.SetTrigger("StartBrakingTriggerReached");
    }
}
