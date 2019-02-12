using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public int speed;
    private bool isShooting = false;

    private Rigidbody2D m_rigidbody;


    private void Awake()
    {
        m_rigidbody = this.GetComponent<Rigidbody2D>();
        speed = 7;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            m_rigidbody.velocity = Vector2.right * speed;
        }

        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            m_rigidbody.velocity = Vector2.left * speed;
        }

        else m_rigidbody.velocity = Vector2.zero;


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }



    private void Shoot()
    {
        if (!isShooting)
        {


            isShooting = true;
        }

    }


}
