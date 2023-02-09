using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    #region Variables
    [SerializeField] private int _totalScore;
    #endregion
    #region Properties
    public int TotalScore { get => _totalScore; }
    #endregion

    private void Awake()
    {
        instance = this;
    }

    public void UpdateScore(int value)
    {
        _totalScore += value;
    }
}
