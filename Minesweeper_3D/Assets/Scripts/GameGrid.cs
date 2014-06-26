using UnityEngine;
using System.Collections;

public class GameGrid : MonoBehaviour {

	private int mines;
	private int rows;
	private int columns;
	private int leftLids;
	private int[,] gameGrid;
	private GameObject[,] lidGrid;
	private PersonMovement characterScript;
	private GameObject minimapPositionSprite;

	public GameObject lidPrefab;
	public GameObject minePrefab;
	public GameObject onePrefab;
	public GameObject twoPrefab;
	public GameObject threePrefab;
	public GameObject fourPrefab;
	public GameObject fivePrefab;
	public GameObject sixPrefab;
	public GameObject sevenPrefab;
	public GameObject eightPrefab;
	public GameObject character;
	public GameObject minimapPosition;


	// Use this for initialization
	void Start () {
		this.mines = 10;
		this.rows = 9;
		this.columns = 9;
		this.leftLids = columns * rows;

		characterScript = character.GetComponent <PersonMovement>();
		initGameGrid();
	}

	public bool isFinished() {
		return leftLids - mines == 0;
	}

	public int getGameGridAtPosition(int row, int column){
		return this.gameGrid [row, column];
	}

	public void deleteLidAtPosition(int row, int column){
		if (hasLidAtPosition(row, column)) {
			Destroy(this.lidGrid[row, column]);
			leftLids--;
		}
	}

	public bool hasLidAtPosition(int row, int column){
		if(this.lidGrid[row, column]){
			return true;
		}else{
			return false;
		}
	}

	private  void initGameGrid(){
		this.gameGrid = new int[this.rows, this.columns];
		this.lidGrid = new GameObject[this.rows, this.columns];
		for(int i = 0; i < this.rows; i++){
			for(int j  = 0; j < this.columns; j++){
				this.gameGrid[i, j] = 0;
				GameObject lidObject = Instantiate(lidPrefab, new Vector3(i+0.5f, 0.1f, j+0.5f), Quaternion.identity) as GameObject;
				lidObject.transform.parent = GameObject.FindWithTag("GameArea").GetComponent<Transform>();
				this.lidGrid[i, j] = lidObject;
			}
		}

		//int seed = 8;
		//Random.seed = seed;

		for (int placedMines = 0; placedMines < mines; placedMines++) {
			int ran = Random.Range (0, (this.rows * this.columns)-1);
			int x = ran % this.columns;
			int y = ran / this.columns;

			while(this.gameGrid[x, y] == 9){	// TODO improve that!!!
				ran = (int)Random.value;
				x = ran % this.columns;
				y = ran / this.columns;
			}


			GameObject mineObject = Instantiate(minePrefab, new Vector3(x+0.5f, 0f, y+0.5f), Quaternion.identity) as GameObject;
			mineObject.transform.parent = GameObject.FindWithTag("GameArea").GetComponent<Transform>();
			this.gameGrid[x, y] = 9;
			for(int i = Mathf.Max(x-1, 0); i <= Mathf.Min(x+1, this.columns-1); i++){
				for(int j = Mathf.Max(y-1, 0); j <= Mathf.Min (y+1, this.rows-1); j++){
					if(this.gameGrid[i, j] != 9){
						this.gameGrid[i, j] += 1;
					}
				}
			}
		}
		GameObject number;
		for(int i = 0; i < this.rows; i++){
			for(int j  = 0; j < this.columns; j++){
				switch (this.gameGrid[i, j]){
				case 1:
					number = onePrefab;
					break;
				case 2:
					number = twoPrefab;
					break;
				case 3:
					number = threePrefab;
					break;
				case 4:
					number = fourPrefab;
					break;
				case 5:
					number = fivePrefab;
					break;
				case 6:
					number = sixPrefab;
					break;
				case 7:
					number = sevenPrefab;
					break;
				case 8:
					number = eightPrefab;
					break;
				default:
					continue;
				}
				GameObject numberObject = Instantiate(number, new Vector3(i+0.5f, 0.01f, j+0.5f), number.transform.rotation) as GameObject;
				numberObject.transform.parent = GameObject.FindWithTag("GameArea").GetComponent<Transform>();
			}
		}
		minimapPositionSprite = Instantiate (minimapPosition, new Vector3(getActualMinimapPosition().x, 0.25f, getActualMinimapPosition().z), minimapPosition.transform.rotation) as GameObject;
		minimapPositionSprite.transform.parent = GameObject.FindWithTag ("GameArea").GetComponent<Transform> ();
	}

	private Vector3 getActualMinimapPosition(){
		Vector3 actualMinimapPosition = characterScript.getCurrentField ();
		actualMinimapPosition.x = actualMinimapPosition.x + 0.5f;
		actualMinimapPosition.z = actualMinimapPosition.z + 0.5f;
		return actualMinimapPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if (minimapPositionSprite != null) {
			minimapPositionSprite.transform.position = new Vector3 (getActualMinimapPosition ().x, 0.25f, getActualMinimapPosition ().z);
		}
	}
}
