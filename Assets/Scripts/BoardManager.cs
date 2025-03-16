using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardManager : MonoBehaviour
{
    private Tilemap m_Tilemap;
    public int width;
    public int height;
    public Tile[] groundTiles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Tilemap = GetComponentInChildren<Tilemap>();

        for (int y = 0; y < height; ++y)
        {
            for (int x = 0; x < width; ++x)
            {
                int tileNumber = Random.Range(0, groundTiles.Length);
                m_Tilemap.SetTile(new Vector3Int(x, y, 0), groundTiles[tileNumber]);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
