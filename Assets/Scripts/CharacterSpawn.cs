using UnityEngine;

public class CharacterSpawn : MonoBehaviour
{
    public Transform[] spawnPoints; // Array of spawn points
    public GameObject[] doors; // Array of doors
    private int currentSpawnIndex; // Index of the current spawn point

    void Start()
    {
        // Randomly select a spawn point and the correct door
        currentSpawnIndex = Random.Range(0, spawnPoints.Length);

        // Spawn the character at the selected spawn point
        SpawnCharacter();
    }

    void Update()
    {
        // Check for door open inputs (1-5)
        for (int i = 0; i < doors.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                OpenDoor(i);
            }
        }

        // Check for door close input (6)
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            CloseDoor();
        }

        // Check for continue input (7)
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            ContinueGame();
        }
    }

    void SpawnCharacter()
    {
        transform.position = spawnPoints[currentSpawnIndex].position;
    }

    void OpenDoor(int doorIndex)
    {
        if (doorIndex == currentSpawnIndex)
        {
            Debug.Log("Correct door opened!");
            // Add logic for correct door opened
        }
        else
        {
            Debug.Log("Wrong door opened!");
            // Add logic for wrong door opened
        }
    }

    void CloseDoor()
    {
        Debug.Log("Closing door and switching position...");
        // Randomly select a new spawn point
        currentSpawnIndex = Random.Range(0, spawnPoints.Length);
        SpawnCharacter();
    }

    void ContinueGame()
    {
        Debug.Log("Continuing game...");
        // Add logic to jump to the next level
    }
}
