using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashEffect : MonoBehaviour {
    private ParticleSystemRenderer particleRenderer;
    public List<Material> materials;
    private void Start()
    {
        particleRenderer = GetComponent<ParticleSystemRenderer>();
    }
    public void SetDashEffect(int index)
    {
    }
}
