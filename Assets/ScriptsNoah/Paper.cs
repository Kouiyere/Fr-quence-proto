using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : MonoBehaviour
{
    private Rigidbody rb;
    public float force = 500f;
    public float upForce = 5f;

    public void Start()
    {
        AudioManager.Instance.PlaySound("PrintPaper", transform.position);
        rb = GetComponent<Rigidbody>();

        // Force vers l'avant en fonction de la rotation locale
        Vector3 forwardDirection = transform.forward * force;

        // Ajoute une dispersion aléatoire autour de cette direction
        Vector3 randomOffset = transform.right * Random.Range(-300f, 100f) +
                               transform.up * upForce;

        rb.AddForce(forwardDirection + randomOffset);
    }
}
