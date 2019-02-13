using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulletController : MonoBehaviour
{

    private Rigidbody2D m_rigidbody;
    private int speed = 17;

    public UnityEvent OnBulletOutOfBounds = new UnityEvent();
    public UnityEvent OnBulletHitEnemy = new UnityEvent();

    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = this.GetComponent<Rigidbody2D>();
        //GameObject player = GameObject.FindGameObjectWithTag("Player");
        //PlayerController controller = player.GetComponent<PlayerController>();
        //OnBulletOutOfBounds.AddListener(controller.OnBulletOutOfBounds);
        OnBulletOutOfBounds.AddListener(PlayerController.OnBulletOutOfBounds);
    }

    // Update is called once per frame
    void Update()
    {
        m_rigidbody.velocity = Vector2.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ceiling"))
        {
            Debug.Log("Ceiling");
            OnBulletOutOfBounds.Invoke();
            Destroy(this.gameObject);
        }

        if (collision.collider.CompareTag("Enemy"))
        {
            //OnBulletHitEnemy.Invoke();
            Destroy(this.gameObject);
        }
    }
}
