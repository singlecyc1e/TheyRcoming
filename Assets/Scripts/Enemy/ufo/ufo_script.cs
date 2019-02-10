using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class onUfoHit : UnityEvent<int>
{
}

public class ufo_script : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    private Rigidbody2D rigidBody;

    public onUfoHit ufoHitEvent = new onUfoHit();
    private List<int> scoreValues = new List<int> { 100, 150, 200, 250, 300 };

    void Awake()
    {
        rigidBody = this.GetComponent<Rigidbody2D>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //spawnLeft();
        move();
        
    }

    void move()
    {
        rigidBody.velocity = new Vector2(speed, 0);
    }

    public void moveRight()
    {
        if (speed < 0) speed = -speed;
    }

    public void moveLeft()
    {
        if (speed > 0) speed = -speed;
    }

    public void spawnLeft()
    {
        rigidBody = this.GetComponent<Rigidbody2D>();
        //rigidBody.velocity = new Vector2(speed, 0);
        moveRight();
        transform.position = new Vector3(-11.0f, 7.0f);
    }

    public void spawnRight()
    {
        rigidBody = this.GetComponent<Rigidbody2D>();
        //rigidBody.velocity = new Vector2(-speed, 0);
        moveLeft();
        transform.position = new Vector3(11.0f, 7.0f);
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        Debug.Log("COLLISION!");
        if (collider.collider.CompareTag("LeftBound") || collider.collider.CompareTag("RightBound"))
        {
            Debug.Log("UFO DESTROYED");
            Destroy(this.gameObject);
        }

        if (collider.collider.CompareTag("Bullet"))
        {
            Debug.Log("BULLET HIT!");
            int randomScore = scoreValues[Random.Range(0, scoreValues.Count)];
            Debug.LogFormat("SCORE SENT: {0}", randomScore);
            ufoHitEvent.Invoke(randomScore);
        }
    }
}
