using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpawner : Spawner
{
    [SerializeField] GameObject ligtpostPrefab;

    public override void SpawnOnePart(){
        Instance = Instantiate(ligtpostPrefab,transform.position,transform.rotation);
    }

    private void Awake() {
        SpawnOnePart();
    }
}
