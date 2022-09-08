using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] VehiclesPrefab;       //Vehicle Prefabs Array
    private Vector3 spawnPositionForVehicle_NoRotation_Road1;       //Spawn Position for vehicles for Road 1
    private Vector3 spawnPositionForVehicle_180Rotation_Road1;       //Spawn Position for vehicles for Road 1
    private Vector3 spawnPositionForVehicle_NoRotation_Road2;       //Spawn Position for vehicles for Road 2
    private Vector3 spawnPositionForVehicle_180Rotation_Road2;       //Spawn Position for vehicles for Road 2
    private Vector3 spawnPositionForVehicle_NoRotation_Road3;       //Spawn Position for vehicles for Road 2
    private Vector3 spawnPositionForVehicle_180Rotation_Road3;       //Spawn Position for vehicles for Road 2


    private PlayerController playerControllerScript;


    private float zAxisSpawnPositionForVehicle = 70;            //Z axis spawn position for vehicle


    private int indexForNoRotaionVehicles_Road1;                          //index for vehicles for Road 1
    private int indexFor180RotaionVehicles_Road1;                          //index for vehicles for Road 1
    private int indexForNoRotaionVehicles_Road2;                          //index for vehicles for Road 2
    private int indexFor180RotaionVehicles_Road2;                          //index for vehicles for Road 2
    private int indexForNoRotaionVehicles_Road3;                          //index for vehicles for Road 3
    private int indexFor180RotaionVehicles_Road3;                          //index for vehicles for Road 3



    private float startDelay = 0f;       //start delay for vehicle
    private float pauseDelay = 2f;       //pause before the next vehicle clones

    void Start()
    {
        InvokeRepeating("SpawnVehicles" , startDelay , pauseDelay);      //calling the spawn vehicle function

        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void SpawnVehicles()
    {
        indexForNoRotaionVehicles_Road1 = Random.Range(0, 3);         //index for vehicles spawning for the array for Road 1 
        indexFor180RotaionVehicles_Road1 = Random.Range(3, 5);

        indexForNoRotaionVehicles_Road2 = Random.Range(0, 3);         //index for vehicles spawning for the array for Road 2
        indexFor180RotaionVehicles_Road2 = Random.Range(3, 5);

        indexForNoRotaionVehicles_Road3 = Random.Range(0, 3);         //index for vehicles spawning for the array for Road 3
        indexFor180RotaionVehicles_Road3 = Random.Range(3, 5);



        //Road 1
        spawnPositionForVehicle_NoRotation_Road1 = new Vector3(-5 , 2 , -zAxisSpawnPositionForVehicle);        //Assigning values to spawn position
        spawnPositionForVehicle_180Rotation_Road1 = new Vector3(0 , 2 , zAxisSpawnPositionForVehicle);
        
        if(playerControllerScript.gameOver == false)
        {
            Instantiate(VehiclesPrefab[indexForNoRotaionVehicles_Road1] , spawnPositionForVehicle_NoRotation_Road1 , VehiclesPrefab[indexForNoRotaionVehicles_Road1].transform.rotation);      //Cloning the prefabs at their location with their rotation
            Instantiate(VehiclesPrefab[indexFor180RotaionVehicles_Road1] , spawnPositionForVehicle_180Rotation_Road1 , VehiclesPrefab[indexFor180RotaionVehicles_Road1].transform.rotation);
        }
        
        //Road 1


        //Road 2
        spawnPositionForVehicle_NoRotation_Road2 = new Vector3(10f , 2 , -zAxisSpawnPositionForVehicle);        //Assigning values to spawn position
        spawnPositionForVehicle_180Rotation_Road2 = new Vector3(15f , 2 , zAxisSpawnPositionForVehicle);

        if(playerControllerScript.gameOver == false)
        {
            Instantiate(VehiclesPrefab[indexForNoRotaionVehicles_Road2] , spawnPositionForVehicle_NoRotation_Road2 , VehiclesPrefab[indexForNoRotaionVehicles_Road2].transform.rotation);      //Cloning the prefabs at their location with their rotation
            Instantiate(VehiclesPrefab[indexFor180RotaionVehicles_Road2] , spawnPositionForVehicle_180Rotation_Road2 , VehiclesPrefab[indexFor180RotaionVehicles_Road2].transform.rotation);
        }
        
        //Road 2


        //Road 3
        spawnPositionForVehicle_NoRotation_Road3 = new Vector3(25f , 2 , -zAxisSpawnPositionForVehicle);        //Assigning values to spawn position
        spawnPositionForVehicle_180Rotation_Road3 = new Vector3(30f , 2 , zAxisSpawnPositionForVehicle);

        if(playerControllerScript.gameOver == false)
        {
            Instantiate(VehiclesPrefab[indexForNoRotaionVehicles_Road3] , spawnPositionForVehicle_NoRotation_Road3 , VehiclesPrefab[indexForNoRotaionVehicles_Road3].transform.rotation);      //Cloning the prefabs at their location with their rotation
            Instantiate(VehiclesPrefab[indexFor180RotaionVehicles_Road3] , spawnPositionForVehicle_180Rotation_Road3 , VehiclesPrefab[indexFor180RotaionVehicles_Road3].transform.rotation);
        }
        
        //Road 3
        
    }
}
