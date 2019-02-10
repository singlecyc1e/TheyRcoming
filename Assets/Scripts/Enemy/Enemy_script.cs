using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_script : MonoBehaviour
{
    public GameObject Enemybullet;
    public EnemySpawn datalibrary;
    public AudioSource due;
    public float speed = 2f;
    public bool firestate = true;
    private float direction = 1f;
    private int rnumber;
    private int row_index;
    private int col_index;
    [SerializeField] private bool lowest = false;
    RaycastHit2D[] _hit;



    private void Update()
    {
        datalibrary = GameObject.Find("Enemy").GetComponent<EnemySpawn>();

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
        //if (this.transform.position.x > datalibrary.rightposition + col_index * 1.8) { direction = 1f; }
        //if (this.transform.position.x < datalibrary.leftposition + col_index * 1.8) { direction = -1f; }
        Move(datalibrary.direction);
        if (datalibrary.downstate) {MoveDown(); datalibrary.downcounter++;}
        if (datalibrary.downcounter == datalibrary.listcounter) { datalibrary.downstate = false; datalibrary.downcounter = 0; }

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("BOOM!!!");
        if (other.tag == "Bullet")
        {
            GameObject.Find("Player").GetComponent<Shooting>().firestate = true;
            datalibrary = GameObject.Find("Enemy").GetComponent<EnemySpawn>();
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
            GameObject.Find("Enemy").GetComponent<EnemySpawn>().direction = -1;
            GameObject.Find("Enemy").GetComponent<EnemySpawn>().downstate = true;
        }

        if (other.tag == "RightBound")
        {
            GameObject.Find("Enemy").GetComponent<EnemySpawn>().direction = 1;
            GameObject.Find("Enemy").GetComponent<EnemySpawn>().downstate = true;
        }
        

        //explosion here
    }

    private void MoveDown()
    {
        this.transform.Translate(Vector2.down);
    }

    private void Shooting()
    {
        Instantiate(Enemybullet, this.transform.position, Quaternion.identity);
        Instantiate(due);
        due.Play();
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
}
