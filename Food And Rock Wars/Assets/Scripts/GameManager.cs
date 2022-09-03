using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour


{

    public GameObject[] stones_gems;
    public float gemzRange = 12.0f;
    public float startDelay = 2.0f;
    public float spawnInterval = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnGems", startDelay, spawnInterval);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnGems()
    {
        int gemIndex = Random.Range(0, stones_gems.Length);
        Vector3 gemPos = new Vector3(10, 2, Random.Range(gemzRange, -gemzRange));
        Instantiate(stones_gems[gemIndex], gemPos, transform.rotation);
    }
}
