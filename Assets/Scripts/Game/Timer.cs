using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ScoreManager))]
public class Timer : MonoBehaviour
{
    public static Timer instance;
    #region Variables
    [SerializeField] private float _counter;
    #endregion
    #region Properties
    public float Counter { get => _counter; set => _counter = value; }
    #endregion
    private void Awake()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        if(GameManager.instance.GameState == GameManager.GameStates.Play)
        {
            TimerFunction();
        }
    }

    private void TimerFunction()
    {
        _counter += Time.deltaTime;
    }
}
