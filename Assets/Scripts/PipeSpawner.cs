using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float maxTime = 2f;
    [SerializeField] private float heightRange = 1.5f;
    [SerializeField] private GameObject _pipe;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        SpawnerPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > maxTime)
        {
            SpawnerPipe();
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    private void SpawnerPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, UnityEngine.Random.Range(-heightRange, heightRange));
        GameObject pipe = Instantiate(_pipe, spawnPos, Quaternion.identity);
        Destroy(pipe, 10f);
    }
}
