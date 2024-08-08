using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        GameObject pipe = PipePool.Instance.GetPipe();
    
        if (pipe != null)
        {
            pipe.transform.position = transform.position + Vector3.up * Random.Range(minHeight, maxHeight);
        }
        else
        {
            Debug.LogError("Pipe cannot be spawned because it is null.");
        }
    }
}