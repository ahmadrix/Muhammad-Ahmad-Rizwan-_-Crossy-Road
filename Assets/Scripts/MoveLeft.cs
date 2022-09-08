using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private PlayerController playerControllerScipt;       //using PlayerController Script


    private float speed = 15;      //variable for controlling cars speed

    private float boundary = 71;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScipt = GameObject.Find("Player").GetComponent<PlayerController>();     //using objects from PlayerController Script
    }

    // Update is called once per frame
    void Update()
    {
        if(playerControllerScipt.gameOver == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);     //moving cars in forward direction
        }
        
        

        if(transform.position.z > boundary && gameObject.CompareTag("Obstacle"))       //Destroy vehicle from left side of road
        {
            Destroy(gameObject);
        }
        else if(transform.position.z < -boundary && gameObject.CompareTag("Obstacle"))      //Destroy vehicle from right side of the road
        {
            Destroy(gameObject);
        }
    }
}
