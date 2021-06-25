using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour
{

    public Animator transitionAnim;
    public GameObject PauseMenu;
    public GameObject Panel;

    void Start()
    {
        PauseMenu.SetActive(false);
        Panel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            pauseGame();
        }
    }

    public void pauseGame()

    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;

        Panel.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        Panel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }

    public void Continue()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        Time.timeScale = 1;
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
