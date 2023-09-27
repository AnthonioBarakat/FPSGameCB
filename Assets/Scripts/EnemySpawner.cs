using System.Collections;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyCharachter;
    [SerializeField]
    private Transform[] spawnerPostition;

   private int randomSide; // see below

    public Path path;

    // we will use Coroutine to be able to create a new monster every intervall of time
    IEnumerator SpawnMonster()
    {   
        while (true)
        {


            yield return new WaitForSeconds(Random.Range(1, 5));

			randomSide = Random.Range(0, spawnerPostition.Length);

            GameObject spawnedEnemy = Instantiate(enemyCharachter, spawnerPostition[randomSide].position,
																   spawnerPostition[randomSide].rotation);
            spawnedEnemy.GetComponent<Enemy>().path = path;
            
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
