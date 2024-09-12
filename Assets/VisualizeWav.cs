using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Seb.Vis;

public class VisualizeWav : MonoBehaviour
{
    [Header("Waves")]
    [SerializeField]
    bool sinusWave;
    [SerializeField]
    bool cosinusWave;

    [Space(5)]

    [Header("Points Settings")]
    [SerializeField]
    float stepSize;
    [SerializeField]
    float length;
    [SerializeField]
    float pointSize;

    void Update()
    {
        Draw.StartLayer(Vector2.zero, 1, false);
        Draw.Point(Vector2.zero, pointSize, Color.white);
    }
}
