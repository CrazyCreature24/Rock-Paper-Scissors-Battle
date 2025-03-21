using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Spawner : MonoBehaviour
{
    // We want to be able to spawn Rock, Paper and scissors pawns from this,
    // with the ability to specify certain amounts,
    // within a certain radius.

    // Collect all spawned pawns in separate arrays or Lists to be accessed later when checking for distances,
    // This should be stored somewhere else

    public short numScissors, numRocks, numPapers = 0;
    public float radius = 200.0f;
    public GameObject scissorsPrefab, rockPrefab, papersPrefab;


    // Start is called before the first frame update
    void Start()
    {
        SpawnPawns(scissorsPrefab, numScissors, PawnTypes.Scissors);
        SpawnPawns(rockPrefab, numRocks, PawnTypes.Rock);
        SpawnPawns(papersPrefab, numPapers, PawnTypes.Paper);

    }

    private void SpawnPawns(GameObject prefab, short num, PawnTypes type)
    {
        for (int i = 0; i < num; i++)
        {
            SpawnPawn(prefab, type);
        }
    }

    private void SpawnPawn(GameObject prefab, PawnTypes type)
    {
        Vector3 spawnLocation = new Vector3(0,0,0);
        spawnLocation = Random.insideUnitSphere * radius;
        spawnLocation.z = 0.0f;

        GameObject temp = Instantiate(prefab, spawnLocation, Quaternion.identity);

        Pawn pawn = temp.GetComponent<Pawn>();

        if (pawn == null)
            Debug.Log("SpawnPawn: pawn variable is null");

        pawn.SetupSpriteRenderer();
        pawn.SetPawnType(type);

        LevelManager.instance.AddToList(temp);
    }
}
