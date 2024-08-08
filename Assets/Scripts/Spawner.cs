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
        GameObject pipes = PipePool.Instance.GetPipe();
        if (pipes == null)
        {
            pipes = Instantiate(PipePool.Instance.pipePrefab);
            pipes.SetActive(false);  // Bu noktada hala pipe'ı pool'a ekleyebiliriz
        }
        pipes.transform.position = transform.position + Vector3.up * Random.Range(minHeight, maxHeight);
    }

}