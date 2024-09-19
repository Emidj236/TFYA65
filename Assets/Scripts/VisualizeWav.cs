using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Seb.Vis;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class VisualizeWav : MonoBehaviour
{
    [Header("Wave file")]
    [SerializeField]
    bool showAudioFile = true;
    [SerializeField]
    float maxScale;

    [Header("Waves")]
    [SerializeField]
    float frequency;
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
    [SerializeField]
    float distance;

    [SerializeField]
    TextMeshPro sinusText;
    [SerializeField]
    TextMeshPro cosinusText;

    AudioSource _audioSource;
    float[] samples = new float[512];

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Draw.StartLayer(Vector2.zero, 1f, false);

        if(!showAudioFile)
        {
            RenderSinWaves();
        } else
        {
            sinusText.gameObject.SetActive(false);
            cosinusText.gameObject.SetActive(false);
            GetSpectrumAudioSource();
            DrawSpectrumData();
        }
    }

    void GetSpectrumAudioSource()
    {
        _audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    void DrawSpectrumData()
    {
        for (int i = 0; i < samples.Length; i++)
        {
            Draw.Quad(new Vector2(i * (length / samples.Length), 0), new Vector2(length / samples.Length, samples[i] * maxScale + 0.05f), pointColor);
        }
    }

    void RenderSinWaves()
    {
        // Text rendering
        sinusText.gameObject.SetActive(true);
        sinusText.gameObject.transform.position = new Vector2(-length / 2.0f + .5f, distance / 2 + amplitude * 6);
        cosinusText.gameObject.SetActive(true);
        cosinusText.gameObject.transform.position = new Vector2(-length / 2.0f + .6f, -distance / 2 + amplitude * 6);

        for (int i = 0; i < Mathf.FloorToInt(length / pointRadius); i++)
        {
            Draw.Point(new Vector2((i * pointRadius) - (length / 2.0f), SinusWave(ref i) + (distance / 2)), pointRadius, pointColor);
        }

        for (int i = 0; i < Mathf.FloorToInt(length / pointRadius); i++)
        {
            Draw.Point(new Vector2((i * pointRadius) - (length / 2.0f), CosinusWave(ref i) - (distance / 2)), pointRadius, pointColor);
        }
    }

    public void ShowAudioFile(bool _bool)
    {
        if(_bool)
        {
            //_audioSource.Play();
        }
        showAudioFile = _bool;
    }

    // Pass by refrence sinus våg
    float SinusWave(ref int _index)
    {
        return Mathf.Sin(_index + Time.time * frequency) * amplitude;
    }

    float CosinusWave(ref int _index)
    {
        return Mathf.Cos(_index + Time.time * frequency) * amplitude;
    }
}
