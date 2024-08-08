using System.Collections.Generic;
using UnityEngine;

public class PipePool : MonoBehaviour
{
    public static PipePool Instance { get; private set; }
    public GameObject pipePrefab;
    private Queue<GameObject> poolQueue = new Queue<GameObject>();
    public int poolSize = 5;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject pipeInstance = Instantiate(pipePrefab);
            pipeInstance.SetActive(false);
            poolQueue.Enqueue(pipeInstance);
        }
    }

    public GameObject GetPipe()
    {
        if (poolQueue.Count == 0)
        {
            // Poolda hiç obje yoksa yeni bir tane oluştur
            GameObject newPipe = Instantiate(pipePrefab);
            newPipe.SetActive(false);
            return newPipe;
        }

        GameObject pipe = poolQueue.Dequeue();
        if (pipe != null && !pipe.activeInHierarchy)
        {
            pipe.SetActive(true);
        }
        else
        {
            // Eğer obje devre dışı ise yenisini oluştur
            pipe = Instantiate(pipePrefab);
        }

        poolQueue.Enqueue(pipe);
        return pipe;
    }

    public void ResetAllPipes()
    {
        foreach (var pipe in poolQueue)
        {
            if (pipe != null)
            {
                pipe.SetActive(false);
                pipe.transform.position = Vector3.zero;
            }
        }
    }
}