using System.Collections;
using System.Collections.Generic; // Necesario para Dictionary
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class GridBuildingSystem : MonoBehaviour
{
    public static GridBuildingSystem current;
    public GridLayout gridLayout;
    public Tilemap MainTileMap;
    public Tilemap TempTileMap;

    public static Dictionary<TileType, TileBase> tileBases = new Dictionary<TileType, TileBase>();

    private Building temp;
    private Vector2 prevPos;


    #region Unity Methods

    private void Awake()
    {
        current = this;
    }

    private void Start()
    {
        string tilePath = "Tiles/"; // Cambié \ por / (más seguro multiplataforma)
        tileBases.Add(TileType.Blanco, Resources.Load<TileBase>(tilePath + "Blanco"));
        tileBases.Add(TileType.Verde, Resources.Load<TileBase>(tilePath + "Verde"));
        tileBases.Add(TileType.Rojo, Resources.Load<TileBase>(tilePath + "Rojo"));
    }

    private void Update()
    {
        // Vacío por ahora
    }

    #endregion

    #region Tilemap Management

    private static TileBase[] GetTilesBlock(BoundsInt area, Tilemap tilemap)
    {
        TileBase[] array = new TileBase[area.size.x * area.size.y * area.size.z];
        int counter = 0;

        foreach (var pos in area.allPositionsWithin)
        {
            array[counter] = tilemap.GetTile(pos);
            counter++;
        }

        return array;
    }

    private static void SetTilesBlock(BoundsInt area, TileType type, Tilemap tilemap)
    {
        int size = area.size.x * area.size.y * area.size.z;
        TileBase[] tileArray = new TileBase[size];
        FillTiles(tileArray, type);
        tilemap.SetTilesBlock(area, tileArray);
    }

    private static void FillTiles(TileBase[] arr, TileType type)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = tileBases[type];
        }
    }

    #endregion

    #region Building Placement
    
    public void InitializeWithBuilding(GameObject building)
    {
        temp = Instantiate(building, Vector3.zero, Quaternion.identity).GetComponent<Building>();
    }

    #endregion
}

public enum TileType
{
    Blanco,
    Verde,
    Rojo
}
