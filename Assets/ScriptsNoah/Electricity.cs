using System.Collections.Generic;
using UnityEngine;

public class Electricity : MonoBehaviour
{
    public GameObject particles;
    public float electricityDuration = 2f;
    public float neighborCheckRadius = 2f;

    private float sourceTimer = 0f;

    private static List<Electricity> allElectricObjects = new List<Electricity>();

    public bool isSource = false;
    public bool isElectrified = false;

    private void Start()
    {
        particles.SetActive(false);
        allElectricObjects.Add(this);
    }

    private void OnDestroy()
    {
        allElectricObjects.Remove(this);
    }

    private void Update()
    {
        if (isSource)
        {
            sourceTimer += Time.deltaTime;
            if (sourceTimer >= electricityDuration)
            {
                isSource = false;
            }
        }

        foreach (var obj in allElectricObjects)
        {
            obj.isElectrified = false;
        }

        foreach (var obj in allElectricObjects)
        {
            if (obj.isSource)
            {
                obj.PropagateElectricity(new HashSet<Electricity>());
            }
        }

        particles.SetActive(isElectrified);
    }

    private void PropagateElectricity(HashSet<Electricity> visited)
    {
        if (visited.Contains(this)) return;
        visited.Add(this);

        isElectrified = true;

        foreach (var neighbor in GetNearbyElectricObjects())
        {
            neighbor.PropagateElectricity(visited);
        }
    }

    private List<Electricity> GetNearbyElectricObjects()
    {
        List<Electricity> neighbors = new List<Electricity>();
        foreach (var other in allElectricObjects)
        {
            if (other == this) continue;
            if ((transform.position - other.transform.position).sqrMagnitude <= neighborCheckRadius * neighborCheckRadius)
            {
                neighbors.Add(other);
            }
        }
        return neighbors;
    }

    private void OnParticleCollision(GameObject particle)
    {
        if (particle.CompareTag("ElectricParticle") && particle != particles)
        {
            BecomeElectricSource();
        }
    }

    private void BecomeElectricSource()
    {
        isSource = true;
        sourceTimer = 0f;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, neighborCheckRadius);
    }
}