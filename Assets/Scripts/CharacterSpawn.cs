using UnityEngine;

public class CharacterSpawn : MonoBehaviour
{
    public Transform[] spawnPoints; // Array of spawn points
    public GameObject[] doors; // Array of doors
    public GameObject[] doorsopen;
    public GameObject Gamewin; // Reference to the Gamewin object
    public GameObject Gameover; // Reference to the Gameover object
    public GameObject ins; // Reference to the ins object

    private int currentSpawnIndex; // Index of the current spawn point

    void Start()
    {
        // Randomly select a spawn point and the correct door
        currentSpawnIndex = Random.Range(0, spawnPoints.Length);

        // Disable all doorsopen and enable all doors
        foreach (var door in doorsopen)
        {
            door.SetActive(false);
        }
        foreach (var door in doors)
        {
            door.SetActive(true);
        }

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

            // Check for door close input (6)
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                CloseDoor(i);
            }
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
            // Disable the opened door and enable the corresponding doorsopen
            doors[doorIndex].SetActive(false);
            doorsopen[doorIndex].SetActive(true);
            Gameover.SetActive(false);
            Gamewin.SetActive(true);
            ins.SetActive(false);
        }
        else
        {
            Debug.Log("Wrong door opened!");
            doors[doorIndex].SetActive(false);
            doorsopen[doorIndex].SetActive(true);
            Gameover.SetActive(true);
            ins.SetActive(false);
        }
    }

    void CloseDoor(int doorIndex)
    {
        Debug.Log("Closing door and switching position...");
        doors[doorIndex].SetActive(true);
        doorsopen[doorIndex].SetActive(false);
        Gamewin.SetActive(false);
        Gameover.SetActive(false);
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
