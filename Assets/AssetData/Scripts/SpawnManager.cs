using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject EnemySpawns;
    [SerializeField]
    private float timeFrame = 3;
    private bool isSpawning = true;
    void Start()
    {
        StartCoroutine(SpawnEnemiesLoop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnEnemiesLoop()
    {
        while (isSpawning)
        {
            Instantiate(EnemySpawns, new Vector3(6.5f, -3, 0), Quaternion.identity);

            yield return new WaitForSeconds(timeFrame * Random.Range(1f, 2f));
        }
    }

    public void StopSpawning()
    {
        isSpawning = false;
    }
}
