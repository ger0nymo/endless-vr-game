using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Transform cube1;
    public Transform player;
    
    bool isIncreasing = false;
    
    // Start is called before the first frame update
    void Start()
    {
        // Player should be 1.41 2.8 -27.77
        player.position = new Vector3(1.5f, 1.2f, -27.77f);
    }

    // Reduce X coordinate of cube1 by 1 unit
    public void ReduceX()
    {
        cube1.position = new Vector3(cube1.position.x - 1, cube1.position.y, cube1.position.z);
    }
    
    void FixedUpdate()
    {
        // Move cube1 between 5 and 18. Switch direction when it reaches either end.
        if (cube1.position.x >= 18)
        {
            isIncreasing = false;
        }
        else if (cube1.position.x <= 5)
        {
            isIncreasing = true;
        }
        
        if (isIncreasing)
        {
            cube1.position = new Vector3(cube1.position.x + 0.1f, cube1.position.y, cube1.position.z);
        }
        else
        {
            cube1.position = new Vector3(cube1.position.x - 0.1f, cube1.position.y, cube1.position.z);
        }
    }
}
