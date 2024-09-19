using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Seb.Vis;

public class VisualizeWav : MonoBehaviour
{
    [Header("Wave file")]
    [SerializeField]
    bool showAudioFile;
    [SerializeField]
    AudioClip audioFile;

    [Header("Waves")]
    [SerializeField]
    bool sinusWave = true;
    [SerializeField]
    bool cosinusWave;
    [SerializeField]
    float waveLength;
    [Space(5)]

    [Header("Point Settings")]
    [SerializeField]
    int length;
    [SerializeField]
    float pointRadius;
    [SerializeField]
    Color pointColor = Color.white;
    [SerializeField]
    float amplitude;

    void Update()
    {
        Draw.StartLayer(Vector2.zero, 1f, false);

        if (!showAudioFile)
        {
            for (int i = 0; i < Mathf.FloorToInt(length / pointRadius); i++)
            {
                if (sinusWave)
                {
                    Draw.Point(new Vector2((i * pointRadius) - (length / 2.0f), SinusWave(ref i)), pointRadius, pointColor);
                }
                else if (cosinusWave)
                {
                    Draw.Point(new Vector2((i * pointRadius) - (length / 2.0f), CosSinusWave(ref i)), pointRadius, pointColor);
                }
            }
        } else if (showAudioFile)
        {
            Debug.Log(audioFile.name);
        }
    }

    // Pass by refrence sinus våg
    float SinusWave(ref int _index)
    {
        return Mathf.Sin(_index * waveLength * Mathf.PI * 2) * amplitude;
    }

    float CosSinusWave(ref int _index)
    {
        return Mathf.Cos(_index * waveLength * Mathf.PI * 2) * amplitude;
    }
}
