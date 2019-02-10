using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_script : MonoBehaviour
{
    public GameObject Enemybullet;
    public EnemySpawn datalibrary;
    public AudioSource due;
    private float speed = 0.7f;
    public bool firestate = true;
    private int rnumber;
    private int row_index;
    private int col_index;
    [SerializeField] private bool lowest = false;
    RaycastHit2D[] _hit;
    public int score = 10;



    private void Update()
    {
        datalibrary = EnemySpawn.EnemyS;

        lowest = NoEnemyinthisdirection(Vector2.down);
        rnumber = Random.Range(0, 2000);
        if (lowest &&  rnumber == 15) { Shooting(); }

        
        for (int i = 0; i < 5; i++)
        {
            for (int k =0; k<11;k++)
            {
                if (datalibrary.EnemyGroup[i,k] == gameObject) {
                    row_index = i;
                    col_index = k;
                }
            }
        }

        Move(datalibrary.direction);
        if (datalibrary.downstate) {MoveDown(); datalibrary.downcounter++; }
        if (datalibrary.downcounter == datalibrary.listcounter) { datalibrary.downstate = false; datalibrary.downcounter = 0; datalibrary.level++; }

    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Bullet")
        {
            GameObject.Find("Player").GetComponent<Shooting>().firestate = true;
            GameObject.Find("UIcontroller").GetComponent<UIcontroller>().scores += score;
            datalibrary = EnemySpawn.EnemyS;
            for (int i = 0; i < 5; i++)
            {
                for (int k = 0; k < 11; k++)
                {
                    if (datalibrary.EnemyGroup[i, k] == gameObject)
                    {
                        datalibrary.EnemyGroup[i, k] = null;
                    }
                }
            }
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            datalibrary.listcounter--;

        }

        if (other.tag == "LeftBound")
        {

            EnemySpawn.EnemyS.direction = -1;
            EnemySpawn.EnemyS.downstate = true;
        }

        if (other.tag == "RightBound")
        {
            EnemySpawn.EnemyS.direction = 1;
            EnemySpawn.EnemyS.downstate = true;
        }

        if (other.tag == "DownBound")
        {
            SceneManager.LoadScene("End");
        }

        if (other.tag == "Player")
        {
            SceneManager.LoadScene("End");
        }


        if (other.tag == "Wall") { Destroy(other.gameObject); }
        //explosion here
    }

    

    private void MoveDown()
    {
        this.transform.Translate(Vector2.down);
    }

    private void Shooting()
    {
        Instantiate(Enemybullet, this.transform.position, Quaternion.identity);
        AudioSource temp =  Instantiate(due);
     
    
    }

    private void Move(float direction)
    {
        this.transform.Translate(Vector2.left * Time.deltaTime * speed * direction);
    }

    private bool NoEnemyinthisdirection(Vector2 direction)
    {
        _hit = Physics2D.RaycastAll(this.transform.position, direction);
        if (_hit.Length >= 2) {
            if (_hit[1].collider.tag == "Enemy") {
                return false;
            }
        }
        return true;
    }

    public float getSpeed()
    {
        return speed;
    }

}
