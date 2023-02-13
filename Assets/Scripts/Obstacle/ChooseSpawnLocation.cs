using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseSpawnLocation : MonoBehaviour
{
    public static ChooseSpawnLocation instance;

    #region Variables
    [SerializeField] private List<GameObject> _spawnLocations;
    private int _randomNumber;
    [SerializeField] Transform _chosenSpawnLocation;
    #endregion
    #region Properties
    public Transform ChosenSpawnLocation { get => _chosenSpawnLocation; }
    #endregion

    private void Awake()
    {
        instance = this;
        _chosenSpawnLocation = _spawnLocations[0].transform;
    }

    public Transform RandomSpawnLocation()
    {
        _randomNumber = Random.Range(0, _spawnLocations.Count);
        return _spawnLocations[_randomNumber].transform;
    }

    public int ReturnRandomSpawnLocation()
    {
        return _randomNumber;
    }
}
