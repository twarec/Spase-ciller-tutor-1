using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumManager : MonoBehaviour {
    public GameObject Enum;
    public float YInit;
    public float TimeInit;

    private float timer;
    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = TimeInit;
            Instantiate(Enum, new Vector3(Random.Range(-10, 10), YInit, 0), Quaternion.identity);
        }
    }
}
