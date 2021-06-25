using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject Fire;

    public ParticleSystem particles;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fire"))
        {
            Fire.gameObject.SetActive(false);
            this.gameObject.SetActive(false);

            particles.Play();
        }

    }
}
