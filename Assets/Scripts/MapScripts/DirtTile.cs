using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class DirtTile : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    public TileBase[] ice;

    public int iceDistribuition;

    public List<TileBase[]> tileBases = new List<TileBase[]>();
    public int mapWidth = 12;
    public int mapHeight = 120;

    TileBase[] topLayer;

    public float magnification;
    int offsetX;
    int offsetY;

    List<List<int>> noiseGrid = new List<List<int>>();

    void Awake()
    {
        topLayer = ice;
        tileBases.Add(ice);
    }

    private void OnEnable()
    {
        offsetX = Random.Range(1, 10000);
        offsetY = Random.Range(1, 10000);
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
        float scalePerlin = clampPerlin * (tileBases.Count + 2);
        if (scalePerlin > tileBases.Count)
        {
            scalePerlin = tileBases.Count;
        }
        return Mathf.FloorToInt(scalePerlin);
    }

    void GenerateMap()
    {
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                int tileID = noiseGrid[x][y];

                if (tileID == tileBases.Count)
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

    string GetNeighbors(int tileID, int x, int y)
    {
        string neighbors = "";

        if (x > 0)
        {
            neighbors += noiseGrid[x - 1][y] > tileID ? "1" : "0"; // Left Center
        }
        else
        {
            neighbors += 0;
        }

        if (x > 0 && y < mapHeight - 1)
        {
            neighbors += noiseGrid[x - 1][y + 1] > tileID ? "1" : "0"; // Top Left
        }
        else
        {
            neighbors += 0;
        }

        if (y < mapHeight - 1)
        {
            neighbors += noiseGrid[x][y + 1] > tileID ? "1" : "0"; // Top Center
        }
        else
        {
            neighbors += 0;
        }

        if (x < mapWidth - 1 && y < mapHeight - 1)
        {
            neighbors += noiseGrid[x + 1][y + 1] > tileID ? "1" : "0"; // Top Right
        }
        else
        {
            neighbors += 0;
        }

        if (x < mapWidth - 1)
        {
            neighbors += noiseGrid[x + 1][y] > tileID ? "1" : "0"; // Right Center
        }
        else
        {
            neighbors += 0;
        }

        if (x < mapWidth - 1 && y > 0)
        {
            neighbors += noiseGrid[x + 1][y - 1] > tileID ? "1" : "0"; // Right Bottom
        }
        else
        {
            neighbors += 0;
        }

        if (y > 0)
        {
            neighbors += noiseGrid[x][y - 1] > tileID ? "1" : "0"; // Bottom Center
        }
        else
        {
            neighbors += 0;
        }

        if (x > 0 && y > 0)
        {
            neighbors += noiseGrid[x - 1][y - 1] > tileID ? "1" : "0"; // Bottom Left
        }
        else
        {
            neighbors += 0;
        }

        return neighbors;
    }

    void SetTopLayer(int x, int y)
    {
        x = x * 3;
        y = y * 3;
        SetTile(new Vector3Int(x, y, 0), topLayer[13]);
        SetTile(new Vector3Int(x, y + 1, 0), topLayer[13]);
        SetTile(new Vector3Int(x, y + 2, 0), topLayer[13]);

        SetTile(new Vector3Int(x + 1, y, 0), topLayer[13]);
        SetTile(new Vector3Int(x + 1, y + 1, 0), topLayer[13]);
        SetTile(new Vector3Int(x + 1, y + 2, 0), topLayer[13]);

        SetTile(new Vector3Int(x + 2, y, 0), topLayer[13]);
        SetTile(new Vector3Int(x + 2, y + 1, 0), topLayer[13]);
        SetTile(new Vector3Int(x + 2, y + 2, 0), topLayer[13]);
    }

    void SetIntermediateLayer(int x, int y, string neighbors, int tileID)
    {
        x = x * 3;
        y = y * 3;
        TileBase[] tileBase;

        tileBase = tileBases[tileID];
        
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
