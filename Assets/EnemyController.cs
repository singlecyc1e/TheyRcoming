using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{

    public class OnBulletHitEnemy : UnityEvent<int> { }

    public int scoreValue = 100;
    private PlayerController player;
    public OnBulletHitEnemy onBulletHitEnemy;

    // Start is called before the first frame update
    void Start()
    {
        onBulletHitEnemy = new OnBulletHitEnemy();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
            Debug.Log("BULLET HIT ENEMY");
            Destroy(this.gameObject);
            onBulletHitEnemy.Invoke(scoreValue);
            player.OnBulletHitEnemyListener(scoreValue);
        }
    }

    public void setScoreValue(int value )
    {
        scoreValue = value;
    }
}
