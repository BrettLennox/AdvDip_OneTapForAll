using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] [Range(5, 10)] private int _scrollFilter = 5;
    [SerializeField] private Vector3 _dir;

    private float _distTravelled;

    // Start is called before the first frame update
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.GameState == GameManager.GameStates.Play)
        {
            _distTravelled += Time.deltaTime * AdjustedScrollSpeed();
            _meshRenderer.material.mainTextureOffset = _dir * _distTravelled;
        }
    }

    private float AdjustedScrollSpeed()
    {
        return SetSpeed.instance.Speed / GameManager.instance.ScrollFilter;
    }
}
