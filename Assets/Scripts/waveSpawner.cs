using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;

public class waveSpawner : MonoBehaviour
{
    //class array waves
    public Wave[] waves;
    //wave delay and the wave index
    [SerializeField] float waveDelay = 10;
    [SerializeField] int waveIndex = 0;
    Vector3 pos;
    //bool
    public bool increaseIndex = false;

    private void Start()
    {
        pos = this.gameObject.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        //removes 1 from wave delay every second
        waveDelay -= Time.deltaTime;
        //if the delay is smaller or equal to 0 do code
        if (waveDelay <= 0)
        {
            //wavedelay is waves int nextwave delay
            waveDelay = waves[waveIndex].nextWaveDelay;
            //print
            print("next wave");
            //starts coroutine with method
            StartCoroutine(WaveSpawner());
        }
        //if bool is equal to true do code
        if (increaseIndex == true)
        {
            //increases the index by 1
            waveIndex++;
            //sets bool to false
            increaseIndex = false;
        }

    }
    private IEnumerator WaveSpawner()
    {
        //for loop i is zero if i is smaller then wave index enemy length add 1 to i
        for (int i = 0; i < waves[waveIndex].enemies.Length; i++)
        {
            //instantiates from the waves index enemy with i
            Instantiate(waves[waveIndex].enemies[i],pos, Quaternion.identity);
            //waits for a amount equal to the next enemy delay
            yield return new WaitForSeconds(waves[waveIndex].nextEnemyDelay);
        }
        //sets increaseindex to true
        increaseIndex = true;
    }
}
[System.Serializable]
//class wave
public class Wave
{
    public EnemyMove[] enemies;
    public float nextEnemyDelay = 0.5f;
    public float nextWaveDelay = 15f;
}
