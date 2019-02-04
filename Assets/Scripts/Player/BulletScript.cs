using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    public float bulletspeed = 7f;
    private float start;
    // Use this for initialization
    void Start()
    {
        start = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
        this.transform.Translate(Vector2.up * bulletspeed * Time.deltaTime);
        if ((this.transform.position.y - start) > 9f) {
            GameObject.Find("Player").GetComponent<Shooting>().firestate = true;
            Destroy(this.gameObject); }
    }


}
