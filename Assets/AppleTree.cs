using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    public GameObject applePrefab;
    public float speedInMPerSec=2f; //

    public float leftAndRightEdge = 10f;

    public float chanceOfDirectionChange = 0.1f; //10% chance to change dirction

    public float appleDropFrquency = 2; //2 apples per second => .5 sec delay => fps/2 frames delay between applae drops




    //private float fps = 1f / Time.inFixedTimeStep; 
    //private float speedInMPerFrame=
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("DropApple", 2f, appleDropFrquency);
    }

    // Update is called once per frame
    void Update()
    {
        //Move
        Vector3 pos = transform.position;
        pos.x += speedInMPerSec * Time.deltaTime;
        transform.position = pos;
        //Check for dir. change and change dir. if becessary
        if (pos.x < -leftAndRightEdge)
        {
            speedInMPerSec = Mathf.Abs(speedInMPerSec);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speedInMPerSec = -Mathf.Abs(speedInMPerSec);
        }
        //check for appl drop and drop if necessary
    }



    void FixeUpdate(){
        // Changing Direction Randomly
        //On 10% chance change direction
        if (Random.value < chanceOfDirectionChange)
        {
            speedInMPerSec *= -1;  // Change direction
        }
    }

    void DropApple()
    {
        GameObject apple = Instantiate(applePrefab) as GameObject;
        apple.transform.position = transform.position;
    }



}
