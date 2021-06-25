using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject Water;
    public GameObject Air;

    public ParticleSystem dust;

    private Vector3 origPos, targetPos;
    private float TimeToMove = 0.2f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach (ContactPoint2D hitPos in collision.contacts)
            {
                if (hitPos.normal.y < 0)
                {
                    Debug.Log("Hit from top");
                    StartCoroutine(MovePlayer(Vector3.down));
                }
                else if (hitPos.normal.y > 0)
                {
                    Debug.Log("Hit from bottom");
                    StartCoroutine(MovePlayer(Vector3.up));
                }

                if (hitPos.normal.x < 0)
                {
                    Debug.Log("Hit from right");
                    StartCoroutine(MovePlayer(Vector3.left));
                }
                else if (hitPos.normal.x > 0)
                {
                    Debug.Log("Hit from left");
                    StartCoroutine(MovePlayer(Vector3.right));
                }
            }
        }

        if (collision.gameObject.CompareTag("Water"))
        {
            Air.gameObject.SetActive(true);
            Water.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }

    }

    private IEnumerator MovePlayer(Vector3 direction)
    {

        float elapsedTime = 0;
        origPos = transform.position;
        targetPos = origPos + direction;

        while (elapsedTime < TimeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / TimeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;
    }


}
