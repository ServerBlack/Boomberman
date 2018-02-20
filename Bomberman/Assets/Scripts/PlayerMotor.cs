using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMotor : MonoBehaviour {

    public Rigidbody2D rb;
    private Vector3 velocity;
    public Tilemap tilemap;
    public Tile[] tiles;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        PerformMovement();
    }

    public void Move(Vector2 _velocity)
    {
        velocity = _velocity;
    }

    void PerformMovement()
    {
        if (velocity != Vector3.zero)
        {
            Vector3Int posDetect = tilemap.WorldToCell(rb.transform.position + velocity);

            Tile tile = tilemap.GetTile<Tile>(posDetect);

            if (tile == null)
                rb.MovePosition(rb.transform.position + velocity);
        }
    }
}
