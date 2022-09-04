using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour


{
    
    private int score;
    public TextMeshProUGUI scoreText;
    public GameObject[] stones_gems;
    public float gemzRange = 12.0f;
    public float startDelay = 2.0f;
    public float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnGems", startDelay, spawnInterval);

        score = 0;
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnGems()
    {
        int gemIndex = Random.Range(0, stones_gems.Length);
        Vector3 gemPos = new Vector3(10, Random.Range(2,4), Random.Range(gemzRange, -gemzRange));
        Instantiate(stones_gems[gemIndex], gemPos, transform.rotation);
        UpdateScore(0);
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }


}
