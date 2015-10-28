/*Created by: Farhana Chowdhury
 Student ID: 300812011
 Source: Comp-305 Professor's uploadded video, Unity 2D Platform Tutorial Video.
 This class was built to provide the methods for spawn of coins  */
using UnityEngine;
using System.Collections;

public class SpawnCoin : MonoBehaviour {

    public Transform[] coinSpawn;
    public GameObject coin;

    // Use this for initialization
    void Start()
    {

        Spawn();
    }

    void Spawn()
    {
        for (int i = 0; i < coinSpawn.Length; i++)
        {
            int coinFlip = Random.Range(0, 2);
            if (coinFlip > 0)
                Instantiate(coin, coinSpawn[i].position, Quaternion.identity);
        }
    }

}
