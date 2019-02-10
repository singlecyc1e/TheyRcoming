using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MFmovement : MonoBehaviour
{
    public float speed = 2f;
    public AudioSource pass;
    public List<int> score;
    public int direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        score.Add(100);
        score.Add(150);
        score.Add(200);
        score.Add(250);
        score.Add(300);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector2.left * Time.deltaTime * speed * direction);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            
            GameObject.Find("UIcontroller").GetComponent<UIcontroller>().scores += score[Random.Range(0,5)];
            GameObject.Find("Player").GetComponent<Shooting>().firestate = true;
            Instantiate(pass);
            Destroy(other.gameObject);
            Destroy(this.gameObject);

        }

        if (other.tag == "LeftBound")
        {
            Destroy(this.gameObject);
            
     
        }
    }
}
