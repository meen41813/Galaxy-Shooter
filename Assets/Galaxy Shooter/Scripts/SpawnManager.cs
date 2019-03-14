using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject[] powerUps;

    private GameManager _gameManager;
   
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
   
        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerUpSpawnRoutine());
    }

    public void StartSpawnRoutine()
    {
        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerUpSpawnRoutine());

    }
    IEnumerator EnemySpawnRoutine()
    {
        while (_gameManager.gameOver ==false)
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(-7.5f, 7.5f), 7.18f, 0),Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }
    }
    IEnumerator PowerUpSpawnRoutine()
    {
        while (_gameManager.gameOver == false)
        {
            int randomPowerUp = Random.Range(0, 3);
            Instantiate(powerUps[randomPowerUp], new Vector3(Random.Range(-7.5f, 7.5f), 7.18f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }
        
    }
}
