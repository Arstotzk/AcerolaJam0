using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isMenuShow = false;
    public GameObject items;
    public GameObject hint;
    public GameObject buttons;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Menu") && !isMenuShow)
        {
            ShowMenu();
        }
        else if (Input.GetButtonDown("Menu") && isMenuShow)
        {
            SuppressMenu();
        }
    }
    public void ShowMenu()
    {
        buttons.SetActive(true);
        items.SetActive(false);
        hint.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        isMenuShow = true;
    }
    public void SuppressMenu()
    {
        buttons.SetActive(false);
        items.SetActive(true);
        hint.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        isMenuShow = false;
    }

    public void Restart()
    {
        SuppressMenu();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
