using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : RoadPart
{
    [SerializeField] protected float rotSpeed, moveSpeed, waveHeight;

    [SerializeField] GameObject PickUpBurst;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Car"){
            Instantiate(PickUpBurst, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
