using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class TileSpawner : MonoBehaviour
{
    public static TileSpawner instance;
    public int gridLength;
    public int gridWidth;

    public Tile[,] tiles;
    public Tile tileToSpawn;
                                                                                                                                                                                                                                                             
    public int randomResourceCount;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        randomResourceCount = Random.Range(1, 10);
        
        tiles = new Tile[gridLength, gridWidth];
       
        for (int i = 0, k = 0; i < gridLength; i++)
        {
            for (int j = 0; j < gridWidth; j++)
            {
                k++;
                tiles[i, j] = Instantiate(tileToSpawn, new Vector3(i, 0, j), Quaternion.identity);
                tileToSpawn.index = new Vector2Int(i,j);
                tiles[i, j].materialCounter = 1000;
            }
        }
        spawnMaterialGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnMaterialGrid()
    {
        for (int i = 0; i < randomResourceCount; i++)
        {
            var randomMaxResourceX = Random.Range(0, gridLength - 1);
            var randomMaxResourceY = Random.Range(0, gridWidth - 1);
            for (int x = randomMaxResourceX - 2; x < randomMaxResourceX + 3; x++)
            {
                for (int y = randomMaxResourceY - 2; y < randomMaxResourceY + 3; y++)
                {
                    if (!(x < 0 || x > gridLength - 1|| y < 0 || y > gridWidth - 1))
                    {
                        tiles[x, y].materialCounter = 3000;
                        if (x == (randomMaxResourceX - 2) || x == (randomMaxResourceX + 2) ||
                            y == (randomMaxResourceY - 2) ||
                            y == (randomMaxResourceY + 2))
                        {
                            tiles[x, y].materialCounter = 2000;
                        }
                    }
                }
                
            }

            tiles[randomMaxResourceX, randomMaxResourceY].materialCounter = 4000;
        }
    }
}
