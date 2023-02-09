using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ScoreManager))]
public class Timer : MonoBehaviour
{
    #region Variables
    [SerializeField] private float timer;
    #endregion
    private void FixedUpdate()
    {
        TimerFunction();
    }

    private void TimerFunction()
    {
        timer += Time.deltaTime;
        if(timer >= 1)
        {
            ScoreManager.instance.UpdateScore(1);
            timer = 0;
        }
    }
}
