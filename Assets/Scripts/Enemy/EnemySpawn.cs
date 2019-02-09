using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public static EnemySpawn EnemyS;
    public GameObject Enemy;
    public GameObject Midterm;
    public GameObject Final;
    public Transform SpawnPoint;
    public Transform FMPoint;
    private GameObject Temp;
    public GameObject[,] EnemyGroup;
    public bool firestate;
    public bool downstate = false;
    public int downcounter = 0;
    public int listcounter = 0;
    public int direction = -1;
    public int level = 0;
    private int canborn = 0;

    private void Awake()
    {
        EnemyS = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        firestate = true;
        EnemyGroup = new GameObject[5,11];

        for (int i = 0; i < 5; i++)
        {
            for (int k = 0; k < 11; k++)
            {
                Temp = Instantiate(Enemy, SpawnPoint.position + new Vector3(k*1.65f,i*1.2f), Quaternion.identity);
                EnemyGroup[i,k] = Temp;
                listcounter++;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (level == 4 && canborn == 0)
        {
            Instantiate(Midterm, FMPoint.position, Quaternion.identity);
            canborn++;
        };

        if (level == 7 && canborn == 1)
        {
            canborn++;
            Instantiate(Final, FMPoint.position, Quaternion.identity);
        };

    }


    private bool IsEmpty()
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
}
