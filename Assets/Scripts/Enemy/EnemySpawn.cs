using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public static EnemySpawn EnemyS;
    public GameObject Enemy;
    public GameObject Midterm;
    public GameObject Final;
    public GameObject Wall;
    public Transform SpawnPoint;
    public Transform FMPoint;
    public Transform WallPoint;
    private GameObject Temp;
    public GameObject[,] EnemyGroup;
    public bool firestate;
    public bool downstate = false;
    public int downcounter = 0;
    public int listcounter = 0;
    public int direction = -1;
    public int level = 0;
    private int canborn = 0;
    private float speed = 2;

    private void Awake()
    {
        EnemyS = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        GenerateWall();
        firestate = true;
        EnemyGroup = new GameObject[5,11];

        for (int i = 0; i < 5; i++)
        {
            for (int k = 0; k < 11; k++)
            {
                Temp = Instantiate(Enemy, SpawnPoint.position + new Vector3(k*1.25f,i*1f), Quaternion.identity);
                if (i < 2) { Temp.GetComponent<Enemy_script>().score = 10; }
                if (2 <= i && i < 4) { Temp.GetComponent<Enemy_script>().score = 20; }
                if (i >= 4) { Temp.GetComponent<Enemy_script>().score = 40; }
                EnemyGroup[i,k] = Temp;
                listcounter++;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (level == 3 && canborn == 0)
        {
            Instantiate(Midterm, FMPoint.position, Quaternion.identity);
            canborn++;
        };

        if (level == 6 && canborn == 1)
        {
            canborn++;
            Instantiate(Final, FMPoint.position, Quaternion.identity);
        };


    }

    public void GenerateWall()
    {
        for (int m =0; m<3; m++) {
            Instantiate(Wall, WallPoint.position + new Vector3(m*4,0), Quaternion.identity);
            Instantiate(Wall, WallPoint.position + new Vector3(0, -.6f) + new Vector3(m * 4, 0), Quaternion.identity);
            Instantiate(Wall, WallPoint.position + new Vector3(.7f, 0) + new Vector3(m * 4, 0), Quaternion.identity);
            Instantiate(Wall, WallPoint.position + new Vector3(1.4f, 0) + new Vector3(m * 4, 0), Quaternion.identity);
            Instantiate(Wall, WallPoint.position + new Vector3(2.1f, 0) + new Vector3(m * 4, 0), Quaternion.identity);
            Instantiate(Wall, WallPoint.position + new Vector3(2.1f, -.6f) + new Vector3(m * 4, 0), Quaternion.identity);
        }

    }

    public bool IsEmpty()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int k = 0; k < 11; k++)
            {
                if (EnemyGroup[i, k] != null) {return false;}
            }
        }
        return true;
    }
    public void NextLevel()
    {
        GenerateWall();
        GameObject.Find("Player").GetComponent<Player_Movement>().health = 3;
        level = 0;
        firestate = true;
        EnemyGroup = new GameObject[5, 11];
        speed += .5f;
        for (int i = 0; i < 5; i++)
        {
            for (int k = 0; k < 11; k++)
            {
                Temp = Instantiate(Enemy, SpawnPoint.position + new Vector3(k * 1.25f, i * 1f), Quaternion.identity);
                Temp.GetComponent<Enemy_script>().speed = speed;
                if (i < 2) { Temp.GetComponent<Enemy_script>().score = 10; }
                if (2 <= i && i < 4) { Temp.GetComponent<Enemy_script>().score = 20; }
                if (i >= 4) { Temp.GetComponent<Enemy_script>().score = 40; }
                EnemyGroup[i, k] = Temp;
                listcounter++;
            }
        }
        GenerateWall();

    }
}
