using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public GameObject Air;

    public ParticleSystem dust;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Air"))
        {
            Air.gameObject.SetActive(false);
            this.gameObject.SetActive(false);


            dust.Play();
        }
    }

}

