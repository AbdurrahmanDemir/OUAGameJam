using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] itemPrefab;
    [SerializeField] float spawn = 0.5f;
    [SerializeField] float[] spawnXValues = { -6.5f, -2.2f, 2.2f, 6.5f };
    

    void Start()
    {
        StartCoroutine(SpawnRandomItem());
    }

    IEnumerator SpawnRandomItem()
    {
        while (true)
        {
            float randomX = spawnXValues[Random.Range(0, spawnXValues.Length)];
            //Vector3 spawnPosition = new Vector3(randomX, transform.position.y);
            Vector3 spawnPosition = new Vector3(randomX, transform.position.y - 1f); // Yükseklik değeri 1f azaltıldı
            
            GameObject gameObject = Instantiate(itemPrefab[Random.Range(0, itemPrefab.Length)], spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawn);

            Destroy(gameObject, 3f);

        }
    }
}

