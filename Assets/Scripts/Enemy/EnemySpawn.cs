using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Enemy;
    public Transform SpawnPoint;
    private GameObject Temp;
    public GameObject[,] EnemyGroup;
    public float leftposition;
    public float rightposition;
    public bool firestate;
    public bool downstate = false;
    public int downcounter = 0;
    public int listcounter = 0;
    private int leftnumber = 0;
    private int rightnumber = 9;
    public int direction = -1;


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

        leftposition = SpawnPoint.position.x - 4F;
        rightposition = SpawnPoint.position.x + 1.6f ;
    }

    // Update is called once per frame
    void Update()
    {

        if (!IsEmpty())
        {
            if (LeftIsNull() )
            {
                leftposition -= 1.8f;
            }

            if (RightIsNull())
            {
                rightposition += 1.8f;
            }
        }

    }

    private bool LeftIsNull()
    {
        for (int i = 0; i < 5; i++)
        {
            if (EnemyGroup[i, leftnumber] != null){ return false; }
        }
        leftnumber++;
        return true;
    }

    private bool RightIsNull()
    {
        for (int i = 0; i < 5; i++)
        {
            if (EnemyGroup[i, rightnumber] != null) { return false; }
        }
        rightnumber--;
        return true;
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
