using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] [Range(5, 10)] private int _scrollFilter = 5;

    // Start is called before the first frame update
    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _meshRenderer.material.mainTextureOffset = new Vector2(0, Time.realtimeSinceStartup * -AdjustedScrollSpeed());
    }

    private float AdjustedScrollSpeed()
    {
        return SetSpeed.instance.Speed / _scrollFilter;
    }
}
