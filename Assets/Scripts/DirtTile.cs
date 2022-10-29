using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class DirtTile : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] public TileBase[] dirt;
    [SerializeField] public TileBase[] ice;

    public static int mapWidth = 10;
    public static int mapHeight = 200;

    float magnification = 4.0f;
    int offsetX;
    int offsetY;

    int numberOfTileMaps = 2;

    List<List<int>> noiseGrid = new List<List<int>>();

    void Awake()
    {
        offsetX = 0; //Random.Range(1, 10000);
        offsetY = 0; //Random.Range(1, 10000);
    }

    void Start()
    {
        GenerateNoiseGrid();
        GenerateMap();
    }

    void GenerateNoiseGrid()
    {
        for (int x = 0; x < mapWidth; x++)
        {
            noiseGrid.Add(new List<int>());
            for (int y = 0; y < mapHeight; y++)
            {
                noiseGrid[x].Add(getIdUsingPerlin(x, y));
            }
        }
    }

    int getIdUsingPerlin(int x, int y)
    {
        float rawPerlin = Mathf.PerlinNoise(
            (x - offsetX) / magnification,
            (y - offsetY) / magnification
        );
        float clampPerlin = Mathf.Clamp(rawPerlin, 0.0f, 1.0f);
        float scalePerlin = clampPerlin * 4;
        if (scalePerlin > 3)
        {
            scalePerlin = 2;
        }
        return Mathf.FloorToInt(scalePerlin);
    }

    void GenerateMap()
    {
        for (int x = 0; x < mapWidth; x++)
        {
            noiseGrid.Add(new List<int>());
            for (int y = 0; y < mapHeight; y++)
            {
                int tileID = getIdUsingPerlin(x, y);

                if (tileID == numberOfTileMaps)
                {
                    SetTopLayer(x, y);
                }
                else
                {
                    string neighbors = GetNeighbors(tileID, x, y);
                    SetIntermediateLayer(x, y, neighbors, tileID);
                }
            }
        }
    }

    string GetNeighbors(int self, int x, int y)
    {
        string neighbors = "";
        neighbors += getIdUsingPerlin(x - 1, y) > self ? "1" : "0";
        neighbors += getIdUsingPerlin(x - 1, y + 1) > self ? "1" : "0";
        neighbors += getIdUsingPerlin(x, y + 1) > self ? "1" : "0";
        neighbors += getIdUsingPerlin(x + 1, y + 1) > self ? "1" : "0";
        neighbors += getIdUsingPerlin(x + 1, y) > self ? "1" : "0";
        neighbors += getIdUsingPerlin(x + 1, y - 1) > self ? "1" : "0";
        neighbors += getIdUsingPerlin(x, y - 1) > self ? "1" : "0";
        neighbors += getIdUsingPerlin(x - 1, y - 1) > self ? "1" : "0";
        return neighbors;
    }

    void SetTopLayer(int x, int y)
    {
        x = x * 3;
        y = y * 3;
        SetTile(new Vector3Int(x, y, 0), dirt[13]);
        SetTile(new Vector3Int(x, y + 1, 0), dirt[13]);
        SetTile(new Vector3Int(x, y + 2, 0), dirt[13]);

        SetTile(new Vector3Int(x + 1, y, 0), dirt[13]);
        SetTile(new Vector3Int(x + 1, y + 1, 0), dirt[13]);
        SetTile(new Vector3Int(x + 1, y + 2, 0), dirt[13]);

        SetTile(new Vector3Int(x + 2, y, 0), dirt[13]);
        SetTile(new Vector3Int(x + 2, y + 1, 0), dirt[13]);
        SetTile(new Vector3Int(x + 2, y + 2, 0), dirt[13]);
    }

    void SetIntermediateLayer(int x, int y, string neighbors, int tileID)
    {
        x = x * 3;
        y = y * 3;
        TileBase[] tileBase;

        if (tileID == 1)
        {
            tileBase = dirt;
        }
        else
        {
            tileBase = ice;
        }
        
        SetTile(new Vector3Int(x, y + 2, 0), GetTile(1, neighbors,tileBase)); // Top Left
        SetTile(new Vector3Int(x + 1, y + 2, 0), GetTile(2, neighbors,tileBase)); // Top Center
        SetTile(new Vector3Int(x + 2, y + 2, 0), GetTile(3, neighbors,tileBase)); // Top Right
        SetTile(new Vector3Int(x + 2, y + 1, 0), GetTile(4, neighbors,tileBase)); // Center Right
        SetTile(new Vector3Int(x + 2, y, 0), GetTile(5, neighbors,tileBase)); // Bottom Right
        SetTile(new Vector3Int(x + 1, y, 0), GetTile(6, neighbors,tileBase)); // Bottom Center
        SetTile(new Vector3Int(x, y, 0), GetTile(7, neighbors,tileBase)); // Bottom Left
        SetTile(new Vector3Int(x, y + 1, 0), GetTile(8, neighbors,tileBase)); // Center Left
        SetTile(new Vector3Int(x + 1, y + 1, 0), GetTile(9, neighbors,tileBase)); // Center Center
    }

    TileBase GetTile(int pos, string neighbors, TileBase[] tileBase)
    {
        string doubleneighbors = neighbors + neighbors;
        string myNeighbors = doubleneighbors.Substring(pos - 1, 3);
        if (myNeighbors == "000") return tileBase[12];
        switch (pos)
        {
            case 1:
                if (myNeighbors == "001" || myNeighbors == "011") return tileBase[1];
                if (myNeighbors == "010") return tileBase[10];
                if (myNeighbors == "100" || myNeighbors == "110") return tileBase[7];
                if (myNeighbors == "111" || myNeighbors == "101") return tileBase[0];
                break;
            case 2:
                if (myNeighbors.Substring(1,1) == "1") return tileBase[1];
                break;
            case 3:
                if (myNeighbors == "001" || myNeighbors == "011") return tileBase[3];
                if (myNeighbors == "010") return tileBase[11];
                if (myNeighbors == "100" || myNeighbors == "110") return tileBase[1];
                if (myNeighbors == "111" || myNeighbors == "101") return tileBase[2];
                break;
            case 4:
                if (myNeighbors.Substring(1, 1) == "1") return tileBase[3];
                break;
            case 5:
                if (myNeighbors == "001" || myNeighbors == "011") return tileBase[5];
                if (myNeighbors == "010") return tileBase[8];
                if (myNeighbors == "100" || myNeighbors == "110") return tileBase[3];
                if (myNeighbors == "111" || myNeighbors == "101") return tileBase[4];
                break;
            case 6:
                if (myNeighbors.Substring(1, 1) == "1") return tileBase[5];
                break;
            case 7:
                if (myNeighbors == "001" || myNeighbors == "011") return tileBase[7];
                if (myNeighbors == "010") return tileBase[9];
                if (myNeighbors == "100" || myNeighbors == "110") return tileBase[5];
                if (myNeighbors == "111" || myNeighbors == "101") return tileBase[6];
                break;
            case 8:
                if (myNeighbors.Substring(1, 1) == "1") return tileBase[7];
                break;
        }
            
        return tileBase[12];
    }

    void SetTile(Vector3Int pos, TileBase tile)
    {         
        tilemap.SetTile(pos, tile);
    }
}
