using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllCollider : MonoBehaviour
{
    [SerializeField]
    Simulation2D simulation;

    public int hZ;
    public float amplitude;

    private void Update()
    {
        simulation.obstacleCentre = new Vector2(-8.3f + amplitude * Mathf.Sin(hZ * Time.time * Mathf.PI * 2), 0);
    }

    public void SetHertz(string hertz)
    {
        hZ = int.Parse(hertz);
    }

    public void SetAmplitude(string _amplitude)
    {
        amplitude = float.Parse(_amplitude);
    }
}
