using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllCollider : MonoBehaviour
{
    [SerializeField]
    Simulation2D simulation;

    public bool changeScale;

    public int hZ;
    public float amplitude;

    public bool pauseObject;

    private void Update()
    {
        if (!pauseObject && !simulation.isPaused)
        {
            Time.timeScale = 1.0f;
            simulation.obstacleCentre1 = new Vector2(-5.0f + (amplitude * Mathf.Cos(hZ * Time.time * Mathf.PI * 2)), 0 /*amplitude * Mathf.Sin(hZ * Time.time * Mathf.PI * 2)*/);
            if (changeScale)
            {
                simulation.obstacleSize1 = new Vector2((amplitude * Mathf.Cos(hZ * Time.time * Mathf.PI * 2)), (amplitude * Mathf.Cos(hZ * Time.time * Mathf.PI * 2)) /*amplitude * Mathf.Sin(hZ * Time.time * Mathf.PI * 2)*/);
            }
        }
        else
        {
            Time.timeScale = 0;
        }
        //simulation.obstacleCentre2 = new Vector2(5.0f + (amplitude * Mathf.Cos(hZ * Time.time * Mathf.PI * 2)), 0 /*amplitude * Mathf.Sin(hZ * Time.time * Mathf.PI * 2)*/);
    }

    public void SetHertz(string hertz)
    {
        hZ = int.Parse(hertz);
    }

    public void SetAmplitude(string _amplitude)
    {
        amplitude = float.Parse(_amplitude);
    }

    public void SetObstacleSize1(string _obstacleSize1)
    {
        simulation.obstacleSize1 = new Vector2(float.Parse(_obstacleSize1), float.Parse(_obstacleSize1));
    }

    public void SetObstacleSize2(string _obstacleSize2)
    {
        simulation.obstacleSize2 = new Vector2(float.Parse(_obstacleSize2), float.Parse(_obstacleSize2));
    }
}
