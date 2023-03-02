using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] float minRepeatTime = 0.5f, maxRepeatTime = 3f;
    float timer, repeatTime;

    protected GameObject Instance;    

    public virtual void SpawnOnePart(){}

    private void Start() {
        timer = 0;
        repeatTime = Random.Range(minRepeatTime, maxRepeatTime);
    }

    private void FixedUpdate() {
        timer+=Time.fixedDeltaTime;
        if (timer>repeatTime){
            timer = 0;
            repeatTime = Random.Range(minRepeatTime, maxRepeatTime);
            SpawnOnePart();
        } 
    }
}
