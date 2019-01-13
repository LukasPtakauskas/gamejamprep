using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class sceneLoad : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] tiles;
    public int mapWidth = 10;
    public int mapHeight = 20;
    public int rectangleCount = 5;
    public float tileSize = 0.1f;
    

    void Start()
    {
        var temp = new List<MapTile>();
        
        // init map
        for (int r = 0; r < rectangleCount; r++)
        {
            int rectWidth = Random.Range(5, mapWidth / 2 / rectangleCount);
            int rectHeight = Random.Range(5, mapHeight / 2 / rectangleCount);
            int offsetX = r == 0 ? 0 : Random.Range(-mapWidth/2, mapWidth/2);
            int offsetZ = r == 0 ? 0 : Random.Range(-mapHeight/2, mapHeight/2);

            for (int i = 0; i < rectWidth; i++)
            {
                for (int j = 0; j < rectHeight; j++)
                {
                    int x = i - rectWidth / 2 + offsetX;
                    int z = j - rectHeight / 2 + offsetZ;
                    
                    Instantiate(GenerateTile(), new Vector3(x, 0, z), Quaternion.identity);

                    bool occupied = GenerateRocks();
                    temp.Add(new MapTile() { x = i, z = j, occupied = occupied, center = j == 0, hasTerrain = true });
                }
            }
        }

        // corridors
        var centers = temp.Where(x => x.center).ToArray();

        var fromX = centers[0].x;
        var fromZ = centers[0].z;
        var toX = centers[1].x;
        var toZ = centers[1].z;

        for (int tempX = fromX; tempX <  Math.Abs(fromX - toX); tempX++)
        {

        }
    }

    private GameObject GenerateTile()
    {
        return tiles[Random.Range(0, tiles.Length)];
    }

    private bool GenerateRocks()
    {
        return Random.Range(0, 1) == 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public class MapTile
    {
        public int x { get; set; }
        public int z { get; set; }
        public bool center { get; set; }
        public bool occupied { get; set; }
        public bool hasTerrain { get; set; }
    }
}

