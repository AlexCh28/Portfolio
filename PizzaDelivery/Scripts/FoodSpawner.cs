using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : Spawner
{
    [SerializeField] List<GameObject> food = new List<GameObject>();

    GameObject foodToSpawn;

    public override void SpawnOnePart(){
        Instance = Instantiate(foodToSpawn,transform.position,transform.rotation);
        foodToSpawn = food[Random.Range(0, food.Count)];
    }

    private void Awake() {
        foodToSpawn = food[0];
    }
}
