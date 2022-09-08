using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public  GameObject player;

    //private variable for the camera position
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3 (-20 , 36 , -1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        //offset the camera behind the player by adding the offset camera value with player position
        transform.position = player.transform.position + offset;
    }
}
