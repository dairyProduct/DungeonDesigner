using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public float particleDuration = 2f; // Adjust this based on your Particle System settings.

    void Start()
    {
        SpawnParticle();
    }

    void SpawnParticle()
    {
        // Destroy the particle instance after its duration.
        Destroy(gameObject, particleDuration);
    }
}
