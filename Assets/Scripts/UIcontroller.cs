using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIcontroller : MonoBehaviour
{
    public Sprite A;
    public Sprite B;
    public Sprite C;
    public GameObject grade;
    public GameObject canvas;
    public GameObject Win;
    public Text WinTEXT;
    public TextMeshPro textPro;
    public int scores = 0;
    public int health = 3;


    void Start()
    {
        canvas.SetActive(false);
        Win.SetActive(false);

    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canvas.SetActive(true);
            Time.timeScale = 0;
        }

        if (GameObject.Find("Player").GetComponent<Player_Movement>().health == 3) { grade.GetComponent<Image>().sprite = A; health = 3; }
        else if (GameObject.Find("Player").GetComponent<Player_Movement>().health == 2) { grade.GetComponent<Image>().sprite = B; health = 2; }
        else if (GameObject.Find("Player").GetComponent<Player_Movement>().health == 1) { grade.GetComponent<Image>().sprite = C; health = 1; }

        textPro.text = scores.ToString();


        if (EnemySpawn.EnemyS.IsEmpty()) {Win.SetActive(true); WinTEXT.text = scores.ToString(); }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Resume()
    {
        Time.timeScale = 1;
        canvas.SetActive(false);
    }

    public void SetZero()
    {
        scores = 0;
    }

    public void WQuit()
    {
        Application.Quit();
    }

    public void NextLevel()
    {
        EnemySpawn.EnemyS.NextLevel();
        Win.SetActive(false);
        
    }
}
