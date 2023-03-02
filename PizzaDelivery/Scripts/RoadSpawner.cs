using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadSpawner : Spawner
{
    [SerializeField] List<GameObject> roadParts = new List<GameObject>();

    GameObject partToSpawn;

    public override void SpawnOnePart(){
        Instance = Instantiate(partToSpawn,transform.position,transform.rotation);
    }

    private void Awake() {
        partToSpawn = roadParts[0];
        SpawnOnePart();
    }   
}
