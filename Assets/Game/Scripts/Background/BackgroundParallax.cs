using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    [SerializeField] private List<BackgroundLayer> _backgroundLayers;
    [SerializeField] private Camera _camera;

    private void Update()
    {
        CalculatePositions();
    }

    private void CalculatePositions()
    {
        foreach (var layer in _backgroundLayers)
        {
            float horizontalDistance = transform.position.x * layer.Displacement;

            int multiplier = Mathf.FloorToInt(transform.position.x * (1 - layer.Displacement) / layer.Size.x);
            horizontalDistance += multiplier * layer.Size.x;

            float horizontalPosition = transform.position.x - horizontalDistance;
            layer.transform.position = new Vector3(horizontalPosition, layer.transform.position.y, 0.0f);
        }
    }
}
