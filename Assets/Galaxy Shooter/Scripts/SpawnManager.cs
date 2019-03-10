using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private GameObject[] powerUps;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerUpSpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator EnemySpawnRoutine()
    {
        while (true)
        {
            Instantiate(enemyPrefab, new Vector3(Random.Range(-7.5f, 7.5f), 7.18f, 0),Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }
    }
    IEnumerator PowerUpSpawnRoutine()
    {
        while (true)
        {
            int randomPowerUp = Random.Range(0, 3);
            Instantiate(powerUps[randomPowerUp], new Vector3(Random.Range(-7.5f, 7.5f), 7.18f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5f);
        }
        
    }
}
