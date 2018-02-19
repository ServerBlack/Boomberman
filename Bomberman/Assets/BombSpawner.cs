using UnityEngine;
using UnityEngine.Tilemaps;

public class BombSpawner : MonoBehaviour {

    public Tilemap tilemap;

    public GameObject bombPrefab;

	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int cell = tilemap.WorldToCell(worldPos);
            Vector3 cellCenterPosition = tilemap.GetCellCenterWorld(cell);

            Instantiate(bombPrefab,cellCenterPosition,Quaternion.identity);
        }
	}
}
