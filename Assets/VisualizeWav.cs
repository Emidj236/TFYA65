using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Seb.Vis;

public class VisualizeWav : MonoBehaviour
{
    [Header("Waves")]
    [SerializeField]
    bool sinusWave = true;
    [SerializeField]
    bool cosinusWave;

    [Space(5)]

    [Header("Point Settings")]
    [SerializeField]
    int length;
    [SerializeField]
    float pointRadius;
    [SerializeField]
    Color pointColor = Color.white;
    [SerializeField]
    int startPointLeft;
    [SerializeField]
    float amplitude;

    Vector2[] positions;

    void Start()
    {
        positions = new Vector2[Mathf.FloorToInt(length / pointRadius)];
    }

    void Update()
    {
        Draw.StartLayer(Vector2.zero, 1f, false);

        Draw.Point(Vector2.zero, pointRadius, pointColor);
    }
}
