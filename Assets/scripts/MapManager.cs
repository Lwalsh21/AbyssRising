
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;
	
	[Header("Map Settings")]
	
	[SerializeField] private int width = 80;
	
	[SerializeField] private int height = 45;
	
	[SerializeField] private int roomMaxSize = 10;
	
	[SerializeField] private int roomMinSize = 6;
	
	[SerializeField] private int maxRooms = 30;
	
	[Header("Colors")]
	
	[SerializeField] private Color32 darkColor = new Color32(0, 0, 0, 0);
	
	[SerializeField] private Color32 lightColor = new Color32(255, 255, 255, 255);
	
	[Header("Tiles")]
	
	[SerializeField] private TileBase floorTile;
	
	[SerializeField] private TileBase wallTile;
	
	[Header("Tilemaps")]
	
	[SerializeField] private Tilemap floorMap;
	
	[SerializeField] private Tilemap obsticalMap;
	
	[Header("Features")]
	
	[SerializeField] private List<RectangularRoom> rooms = new List<RectangularRoom>();
	
	public TileBase FloorTile { get => floorTile; }
	
	public TileBase WallTile { get => wallTile; }
	
	public Tilemap FloorMap { get => floorMap; }
	
	public Tilemap ObsticalMap { get => obsticalMap; }
	
	//import system genaric
	public List<RectangularRoom> Rooms { get => rooms; }
	
	private void Awake()
	{
		if (instance == null)
			instance = this;
		else
			Destroy(gameObject);
	}
    void Start()
    {
       
		 ProGen progen = new Progen();
		 progen.GenerateDungeon(width, height, roomMinSize, maxRooms, rooms);
	   
	   
		Instantiate(Resources.Load(GameObject>("NPC"), new Vector3(40 - 5.5f, 25 + 0.5f, 0), Quaternion.identity).name = "NPC";
	
		Camera.main Transform.position = new Vector3(40, 20.25f, -10);
		Camera.Main.orthographicSize = 27;

    }
	
	public bool InBounds(int x, int y) => 0 <= x && x < width && 0 <= y && y < height;
	
	public void CreatePlayer(Vector2 position)
	{
		Instantiate(Resources.Load<GameObject>("Player"), new Vector3(position.x + 0.5f, position.y + 0.5f, 0), Quaternion,identity).name = "Player";
		
	}
}
