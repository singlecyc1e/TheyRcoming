using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WALL : MonoBehaviour
{
    
    public Sprite level4;
    public Sprite level3;
    public Sprite level2;
    public Sprite level1;
    public int health = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (health == 3) { this.GetComponent<SpriteRenderer>().sprite = level3; }
        else if (health == 2) { this.GetComponent<SpriteRenderer>().sprite = level2; }
        else if (health == 1) { this.GetComponent<SpriteRenderer>().sprite = level1; }
        else if (health == 0) { Destroy(this.gameObject); }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Bullet")
        {

            GameObject.Find("Player").GetComponent<Shooting>().firestate = true;
            health--;
            Destroy(other.gameObject);
        }

        if (other.tag == "EnemyBullet")
        {
        
            health--;
            Destroy(other.gameObject);
        }
    }
}
