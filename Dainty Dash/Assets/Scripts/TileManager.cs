using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    public GameObject[] tilePrefabs;
    private List <GameObject> activeTiles;
    private Transform playerTransform;
    private int lastPrefabIndex = 0;
    
    private float spawnZ = -1.8994675f;
    private float tileLength = 3.798935f;
    private int tilesOnScreen = 8;
    private float destroyDelay = 10.0f;          //10 metres approx 2 sec to destroy a tile
    
    
    
    // Start is called before the first frame update
    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        activeTiles = new List<GameObject>();

        for (int i = 0; i < tilesOnScreen; i++)
        {
            if (i < 6)

                SpawnTile(0);

            else
                
                SpawnTile();


        }
        

    }

    // Update is called once per frame
    private void Update()
    {
        if (playerTransform.position.z - destroyDelay> (spawnZ - tilesOnScreen * tileLength))
        {
            SpawnTile();
            DeleteTile();
        }
    }

    private void SpawnTile (int prefabIndex = -1)                //picks a random tile
    {
        GameObject reference;                                   //tile spawn becomes child of tile mnager clutter free hierarchy

        if (prefabIndex == -1)

            reference = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;

        else

            reference = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
        
        reference.transform.SetParent(transform);
        
        reference.transform.position = Vector3.forward * spawnZ;
        
        spawnZ += tileLength;
        activeTiles.Add(reference);
    }

    private int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
            return 0;

        int randomIndex = lastPrefabIndex;

        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);   //destroy from index

        activeTiles.RemoveAt (0);  //remove from list
    }
}
