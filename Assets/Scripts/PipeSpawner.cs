using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//sinh ống
public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float maxTime = 2, heightRange = 1.5f;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > maxTime)
        {
            timer = 0;
            SpawnerPipe();
        }
    }

    private void SpawnerPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-heightRange, heightRange), 0);
        GameObject pipe = Instantiate(pipePrefab, spawnPos, Quaternion.identity);
        Destroy(pipe, 5f);
    }
}
