using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

    public int DoorDirection;
    //  0 --> Right
    //  1 --> Top
    //  2 --> Left
    //  3 --> Bottom
    public bool Spawned = false;
    private RoomTemplates Templates;
    private int RandomNumber;

    void Start()
    {
        // accessing the Rooms array in the RoomTemplates script in the Rooms Temptale GameObject
        Templates = GameObject.FindGameObjectWithTag("DungeonRooms").GetComponent<RoomTemplates>();

        // Invoke calls a function with a time delay, so that rooms can detect the collisions ..
        Invoke("Spawn", .5f); 
    }

    void Spawn()
    {
        if (Spawned == false)
        {
            switch (DoorDirection)
            {
                case 0:
                    // Spawn a room with Right Door
                    RandomNumber = Random.Range(0, Templates.RightDoorRooms.Length - 1);
                    Instantiate(Templates.RightDoorRooms[RandomNumber], transform.position, Templates.RightDoorRooms[RandomNumber].transform.rotation);
                    break;
                case 1:
                    // Spawn a room with Top Door
                    RandomNumber = Random.Range(0, Templates.TopDoorRooms.Length - 1);
                    Instantiate(Templates.TopDoorRooms[RandomNumber], transform.position, Templates.TopDoorRooms[RandomNumber].transform.rotation);
                    break;
                case 2:
                    // Spawn a room with Left Door
                    RandomNumber = Random.Range(0, Templates.LeftDoorRooms.Length - 1);
                    Instantiate(Templates.LeftDoorRooms[RandomNumber], transform.position, Templates.LeftDoorRooms[RandomNumber].transform.rotation);
                    break;
                case 3:
                    // Spawn a room with Bottom Door
                    RandomNumber = Random.Range(0, Templates.BottomDoorRooms.Length - 1);
                    Instantiate(Templates.BottomDoorRooms[RandomNumber], transform.position, Templates.BottomDoorRooms[RandomNumber].transform.rotation);
                    break;
            }
            Spawned = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            Destroy(gameObject);
        }
    }


}
