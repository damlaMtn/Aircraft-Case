using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public Plane area;

    public GameObject checkpointPrefab;
    public int checkpointCount = 6;

    private void Start()
    {
        for (int i = 0; i < checkpointCount; i++)
        {
            GameObject checkpoint = Instantiate(checkpointPrefab, this.transform);
            Vector3 randomLocation = new Vector3(Random.Range(-800, 800), 10, Random.Range(250, 2000));
            checkpoint.transform.localPosition = randomLocation;
        }
    }
}
