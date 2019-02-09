using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
    // Use this for initialization
    public static Shooting Shoot;
    public bool firestate = true;
    public GameObject bullet;
    public Transform firepoint;

	void Awake () {
        Shoot = this;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && firestate) {
            firestate = false;
            Instantiate(bullet,firepoint.position,Quaternion.identity);
        }
	}

}
