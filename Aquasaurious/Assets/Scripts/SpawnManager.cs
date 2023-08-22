using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{

    public GameObject player;
    private PlayerScore ps;
    private PlayerMovement pm;
    public GameObject[] objects;
    public GameObject fish, killFish;
    public Transform ground;

    public bool stopSpawning = false;
    private bool kf = false;

    private int localDifficulty;

    private IEnumerator spawnFishCR, spawnObjectsCR, spawnKillFishCR;

    private float OBJECT_INTERVAL = 1.0f;
    private float FISH_INTERVAL = 1.5f;
    private float KILLFISH_INTERVAL = 2.0f;

    int[] zValues = new int[] {-25, -15, 0, 0, 20};
 
    void Start()
    {
        ps = player.GetComponent<PlayerScore>();
        pm = player.GetComponent<PlayerMovement>();

        spawnObjectsCR = SpawnObjects(OBJECT_INTERVAL);
        spawnFishCR = SpawnFish(FISH_INTERVAL);
        spawnKillFishCR = SpawnKillFish(KILLFISH_INTERVAL);

        localDifficulty = pm.level;

        // InvokeRepeating("SpawnObjects", 0.0f, OBJECT_INTERVAL);
        // InvokeRepeating("SpawnFish", 0.0f, FISH_INTERVAL);

        StartCoroutine(spawnObjectsCR);
        StartCoroutine(spawnFishCR);
    }

    void Update() {

        /* This section of code prevents the spawner from sending objects down the
        * center lane so when the player spawns, they don't have to worry about
        * colliding with any active elements when they are not ready to. 
        */
        if(pm.isDead) zValues = new int[] {-20, -15, -10, 10, 20};
        else zValues = new int[] {-25, -15, 0, 0, 20};

        if(localDifficulty < pm.level) increaseDifficulty();

        // This section of code begins spawning kill fish once the players score is >= 25
        if(ps.score >= 25 && !kf) {
            StartCoroutine(SpawnKillFish(KILLFISH_INTERVAL));
            kf = true;
        }

    }

    public void StopAllCoroutines() {
        StopCoroutine(spawnFishCR);
        StopCoroutine(spawnObjectsCR);
        StopCoroutine(spawnKillFishCR);
    }

    public void StartAllCoroutines() {
        spawnObjectsCR = SpawnObjects(OBJECT_INTERVAL);
        spawnFishCR = SpawnFish(FISH_INTERVAL);
        spawnKillFishCR = SpawnKillFish(KILLFISH_INTERVAL);

        StartCoroutine(spawnFishCR);
        StartCoroutine(spawnObjectsCR);
        if(kf) StartCoroutine(spawnKillFishCR);
    }

    public void increaseDifficulty() {
        StopAllCoroutines();
        
        localDifficulty = pm.level;
        OBJECT_INTERVAL -= 0.1f;
        FISH_INTERVAL -= 0.1f;
        KILLFISH_INTERVAL -= 0.1f;

        StartAllCoroutines();
    }

    IEnumerator SpawnObjects(float intervalTime)
    {
        while(!stopSpawning)
        {
            Vector3 randomSpawnPosition;
            int randomObject = Random.Range(0,3);
            int randomZ = Random.Range(0,5);

            if(objects[randomObject].gameObject.CompareTag("Ground")) {
                randomSpawnPosition = new Vector3(50, ground.position.y, zValues[randomZ]);
            } else {
                randomSpawnPosition = new Vector3(50, Random.Range(-8,8), zValues[randomZ]);
            }

            Instantiate(objects[randomObject], randomSpawnPosition, Quaternion.identity);

            yield return new WaitForSecondsRealtime(intervalTime);
        }
    }

    IEnumerator SpawnFish(float intervalTime)
    {
        while(!stopSpawning)
        {
            Vector3 randomSpawnPosition = new Vector3(50, Random.Range(-10,11),0);
            Instantiate(fish,randomSpawnPosition,Quaternion.identity);

            yield return new WaitForSecondsRealtime(intervalTime);
        }
    }

    IEnumerator SpawnKillFish(float intervalTime)
    {
        while(!stopSpawning)
        {
            Vector3 randomSpawnPosition = new Vector3(50, Random.Range(-10,11),0);
            Instantiate(killFish,randomSpawnPosition,Quaternion.identity);

            yield return new WaitForSecondsRealtime(intervalTime);
        }
    }
}
