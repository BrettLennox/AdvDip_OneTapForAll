using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseSpawnLocation : MonoBehaviour
{
    public static ChooseSpawnLocation instance;

    #region Variables
    [SerializeField] private List<GameObject> _spawnLocations;
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
        int randomNumber = Random.Range(0, _spawnLocations.Count);
        return _chosenSpawnLocation = _spawnLocations[randomNumber].transform;
    }
}
