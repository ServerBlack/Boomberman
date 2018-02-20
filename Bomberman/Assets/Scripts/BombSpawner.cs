using UnityEngine;
using UnityEngine.Tilemaps;

public class BombSpawner : MonoBehaviour {

    public Tilemap tilemap;

    public GameObject bombPrefab;

	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnBomb(Input.mousePosition);
            
        }
	}

    public void SpawnBomb(Vector3 _coordinate)
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(_coordinate);
        Vector3Int cell = tilemap.WorldToCell(worldPos);
        Vector3 cellCenterPosition = tilemap.GetCellCenterWorld(cell);

        GameObject bomb = Instantiate(bombPrefab,cellCenterPosition,Quaternion.identity);
    }

    public void SpawnBomb2(Vector3 _coordinate)
    {
        GameObject bomb = Instantiate(bombPrefab,_coordinate,Quaternion.identity);
    }
}
