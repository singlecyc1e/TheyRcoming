using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MFmovement : MonoBehaviour
{
    public float speed = 2f;
    public AudioSource pass;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector2.left * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
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
