using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float bulletspeed = 4f;
    private float start;
    // Use this for initialization
    void Start()
    {
        start = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.Translate(Vector2.down * bulletspeed * Time.deltaTime);
        if ((start - this.transform.position.y) > 10f)
        {
            GameObject.Find("Enemy").GetComponent<EnemySpawn>().firestate = true;
            Destroy(this.gameObject);
        }
    }
}
