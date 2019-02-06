using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ufo_script : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveRight();
    }

    void moveRight()
    {
        rigidBody.velocity = new Vector2(speed, 0);
    }


}
