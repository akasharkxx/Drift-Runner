using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private Vector2 distanceBetween;
    [SerializeField] private float timeBetweenNewSpawns, destroyTime;
    [SerializeField] private int numberOfPlatformsToSpawn;

    private Vector3 currentPosition;
    private float elapsedTime;

    private void Start()
    {
        elapsedTime = 0f;
        currentPosition = transform.position;
        SpawnPlatforms();
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime >= timeBetweenNewSpawns)
        {
            SpawnPlatforms();
            elapsedTime = 0f;
        }
    }

    private void SpawnPlatforms()
    {
        for (int i = 0; i < numberOfPlatformsToSpawn; i++)
        {
            GameObject platformSpawned = Instantiate(platformPrefab, currentPosition, Quaternion.identity);
            platformSpawned.name = "cube" + i.ToString();

            int newX = Mathf.RoundToInt(Random.Range(-distanceBetween.x, distanceBetween.x));
            currentPosition = new Vector3(newX, 0f, platformSpawned.transform.position.z + distanceBetween.y);
            Destroy(platformSpawned, destroyTime);
        }
    }

}
