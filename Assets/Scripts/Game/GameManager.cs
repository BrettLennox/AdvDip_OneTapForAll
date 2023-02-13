using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public enum GameStates
    {
        Pause, Play, Menu
    }

    #region Variables
    [SerializeField] private GameStates _gameState;
    [SerializeField] [Range(1, 10)] private int _scrollFilter; 
    #endregion
    #region Properties
    public GameStates GameState { get => _gameState; set => _gameState = value; }
    public int ScrollFilter { get => _scrollFilter; }
    #endregion

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        if(_gameState == GameStates.Play)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _gameState = GameStates.Pause;
            }
        }
    }
}
