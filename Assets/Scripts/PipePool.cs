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

        for (int i = 0; i < poolSize; i++)
        {
            GameObject pipe = Instantiate(pipePrefab);
            pipe.SetActive(false);
            poolQueue.Enqueue(pipe);
        }
    }

    public GameObject GetPipe()
    {
        GameObject pipe = poolQueue.Dequeue();
        pipe.SetActive(true);
        poolQueue.Enqueue(pipe);
        return pipe;
    }

    public void ResetAllPipes()
    {
        foreach (var pipe in poolQueue)
        {
            if (pipe != null)  // Null kontrolü ekliyoruz
            {
                pipe.SetActive(false);  // Boruları devre dışı bırakıyoruz
                pipe.transform.position = Vector3.zero;  // Boruların pozisyonunu sıfırlıyoruz
            }
        }
    }

}