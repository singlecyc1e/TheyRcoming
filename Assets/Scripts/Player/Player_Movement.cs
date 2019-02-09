using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{
    public Transform rebirthpoint;
    public int health = 3;
    public float speed = 5f;
    public Animator animator;
    public bool failstate = false;

    void Update()
    {

        //this.transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0) * speed * Time.deltaTime);
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxisRaw("Horizontal"), 0) * speed ;

        if (failstate)
        {
            animator.SetInteger("Direction", 4);
        }

        if (Input.GetKey(KeyCode.A) |  Input.GetKey(KeyCode.LeftArrow) )
        {
            animator.SetInteger("Direction", 1);
        }


        if (Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetInteger("Direction", 2);
        }

        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.LeftArrow) && !failstate)
        {
            animator.SetInteger("Direction", 0);
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "EnemyBullet") {
            health--;
            Destroy(collision.collider.gameObject);
            animator.SetInteger("Direction", 4);
            StartCoroutine(Waiter());
        }

    }

    IEnumerator Waiter()
    {
        Time.timeScale = .0000001f;
        failstate = true;
        animator.SetInteger("Direction", 4);
        yield return new WaitForSeconds(1* .0000001f);
        failstate = false;
        transform.position = rebirthpoint.position;
        Time.timeScale = 1;
        if (health == 0) { SceneManager.LoadScene("End"); }
    }
}
 
