using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public GameObject Earth;

    public ParticleSystem dust;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Earth"))
        {
            Earth.gameObject.SetActive(false);
            this.gameObject.SetActive(false);

            dust.Play();
        }

    }
}
