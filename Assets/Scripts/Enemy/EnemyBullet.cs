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
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "DownBound") { Destroy(this.gameObject); }
        if (collision.collider.tag == "Wall") { Destroy(this.gameObject); }
    }
}
