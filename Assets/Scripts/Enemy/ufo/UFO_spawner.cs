using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO_spawner : MonoBehaviour
{

    public GameObject ufo;
    private float spawnRatio = 0.2f;
    private bool ufoExists = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!ufoExists)
        {
            if (Random.value < spawnRatio)
            {
                ufoExists = true;
                Instantiate(ufo);
                if (Random.value > 0.5f)
                {
                    ufo.GetComponent<ufo_script>().spawnRight();
                }
                else
                {
                    ufo.GetComponent<ufo_script>().spawnLeft();
                }
            }
        }
        
    }
}
