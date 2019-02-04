using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D _hit = Physics2D.Raycast(transform.position, Vector2.down);
        Debug.DrawRay(transform.position, Vector2.down, Color.black);
        if (_hit.collider) {
            Debug.Log("here222");
            Debug.DrawRay(transform.position, Vector2.down, Color.black);
            if (_hit.collider.tag == "Enemy") {
                
            }
        }
    }
}
