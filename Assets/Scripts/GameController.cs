using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    GameObject hazard;
    [SerializeField]
    int spawnCount;
    [SerializeField]
    float spawnWait;
    [SerializeField] 
    float startWait;
    [SerializeField]
    float waveWait;

    void Start()
    {
        StartCoroutine(SpawnValues());
    }

    IEnumerator SpawnValues()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for(int i = 0; i<spawnCount; i++) 
            { 
                Vector3 spawnPosition = new Vector3(Random.Range(-2.9f,2.9f),0,9);
                Quaternion spawnRotation = Quaternion.identity;

                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
    }
}
