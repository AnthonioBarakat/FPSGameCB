using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyCharachter;
    [SerializeField]
    private Transform[] spawnerPostition;

    private GameObject spawnedEnemy;
    private int randomSide; // see below


    // we will use Coroutine to be able to create a new monster every intervall of time
    IEnumerator SpawnMonster()
    {
        while (true)
        {

            yield return new WaitForSeconds(Random.Range(1, 5));
        
            randomSide = Random.Range(0, spawnerPostition.Length);

            spawnedEnemy = Instantiate(enemyCharachter);


            spawnedEnemy.transform.position = spawnerPostition[randomSide].position;
            
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonster());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
