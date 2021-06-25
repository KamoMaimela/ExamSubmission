using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;
    public LayerMask whatStopMovement;

    public ParticleSystem dust;

    public GameObject Panel;
    public GameObject StarSystem;

    public Image Star1;
    public Image Star2;
    public Image Star3;

    public float seconds = 0f;

    void Start()
    {
        movePoint.parent = null;
    }

    
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, whatStopMovement)) 
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
               
            }
            else // to avoid moving diagonally

            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, whatStopMovement)) 
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
               
            }
           


        }

        if (Input.GetKey("up"))
        {
            this.transform.rotation = Quaternion.Euler(Vector3. forward * 180f);
            CreateDust();
        }
        if (Input.GetKey("down"))
        {
            this.transform.rotation = Quaternion.Euler(Vector3.forward * 0f);
            CreateDust();
        }
        if (Input.GetKey("left"))
        {
            this.transform.rotation = Quaternion.Euler(Vector3.forward * 270f);
        }
        if (Input.GetKey("right"))
        {
            this.transform.rotation = Quaternion.Euler(Vector3.forward * 90f);    
        }


        seconds += Time.deltaTime;

        if(seconds <= 50f)
        {
            Star1.gameObject.SetActive(true);
            Star2.gameObject.SetActive(true);
            Star3.gameObject.SetActive(true);
        }

        if(seconds > 50f && seconds <= 90f)
        {
            Star1.gameObject.SetActive(true);
            Star2.gameObject.SetActive(true);
            Star3.gameObject.SetActive(false);
        }

        if(seconds > 90f)
        {
            Star1.gameObject.SetActive(true);
            Star2.gameObject.SetActive(false);
            Star3.gameObject.SetActive(false);
        }
    
    }

    void CreateDust()
    {
        dust.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag("Hole"))
       {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        }

       if (collision.gameObject.CompareTag("Exit"))
       {
            Panel.gameObject.SetActive(true);
            StarSystem.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        }

    }

   
}
