using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapDestroyer : MonoBehaviour {

    public Tilemap tilemap;

    public Tile wallTile;
    public Tile destructibleTile;

    public GameObject explosionPrefab;

	public void Explode(Vector2 worldPos)
    {
        Vector3Int originCell = tilemap.WorldToCell(worldPos);

        ExplodeCell(originCell);
        ExplodeCell(originCell + new Vector3Int(1,0,0));
        ExplodeCell(originCell + new Vector3Int(-1,0,0));
        ExplodeCell(originCell + new Vector3Int(0,1,0));
        ExplodeCell(originCell + new Vector3Int(0,-1,0));
    }

    bool ExplodeCell(Vector3Int cell)
    {
        Tile tile = tilemap.GetTile<Tile>(cell);

        if (tile == wallTile)
            return false;
        if(tile == destructibleTile)
        {
            tilemap.SetTile(cell,null);
        }


        Vector3 pos = tilemap.GetCellCenterWorld(cell);
        GameObject effect = Instantiate(explosionPrefab,pos,Quaternion.identity);
        Destroy(effect,2f);

        return true;
    }
}
