using UnityEngine;

public class CharacterSpawn : MonoBehaviour
{
    public Transform[] spawnPoints; // Array of potential spawn points
    public Transform targetPoint; // The point to move to after the door closes
    private Transform character;
    private bool hasSpawned = false; // Flag to ensure the character spawns only once

    void Start()
    {
        if (!hasSpawned)
        {
            SpawnCharacter();
            hasSpawned = true;
        }
    }

    void SpawnCharacter()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        character = Instantiate(gameObject, spawnPoints[randomIndex].position, Quaternion.identity).transform;
    }

    public void OnDoorClosed()
    {
        MoveCharacterToTarget();
    }

    void MoveCharacterToTarget()
    {
        if (character != null && targetPoint != null)
        {
            character.position = targetPoint.position;
        }
    }
}
