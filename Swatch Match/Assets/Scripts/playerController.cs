using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class playerController : MonoBehaviour
{
    string playerInput;
    grid mygrid;
    GameObject swapTile;
    GameObject myTile;
    public GameObject myPlayer;
    private int moves;
    public char column;
    public char row;
    private GameObject[,] _allTiles;
    private GameObject playerTile;
    private GameObject targetTile;
    public TextMeshProUGUI playerMoves;

    //Positions of GameObjects within the array
    private Vector2Int playerTilePos;
    private Vector2Int targetTilePos;
    

    //Actual Spaces where Tiles should be in the game world
    private Vector2 tempPos;

    // Start is called before the first frame update
    void Start()
    {
        mygrid = FindObjectOfType<grid>();
        mygrid.GetComponent<grid>().generateGrid();
        _allTiles = mygrid.GetComponent<grid>().allTiles;
        playerTilePos = new Vector2Int(2, 3);
        moves = 6;
       
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow)){
               
               Swap("up");
            }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {

            Swap("down");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
           
            Swap("right");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {

            Swap("left");
        }


        if(moves <= 0)
        {
            SceneManager.LoadScene(1);
        }

    }


    private void Swap(string direction)
    {
        bool moved = false;

        if (direction == "up" && playerTilePos.y != 0 && moved == false)
        {

            targetTilePos = new Vector2Int(playerTilePos.x, playerTilePos.y - 1);
            playerTile = _allTiles[playerTilePos.x, playerTilePos.y];
            targetTile = _allTiles[targetTilePos.x, targetTilePos.y];

            tempPos = playerTile.transform.position;
            playerTile.transform.position = targetTile.transform.position;
            targetTile.transform.position = tempPos;
            playerTilePos.y -= 1;
            targetTilePos.y += 1;
            _allTiles[playerTilePos.x, playerTilePos.y] = playerTile;
            _allTiles[targetTilePos.x, targetTilePos.y] = targetTile;
            playerTile.transform.name = playerTilePos.x + "," + playerTilePos.y;
            targetTile.transform.name = targetTilePos.x + "," + targetTilePos.y;

            myPlayer.transform.GetChild(0).transform.GetChild(0).transform.position = new Vector2(playerTile.transform.position.x + 0.05f, playerTile.transform.position.y - 0.05f);
            moved = true;
            
        }
        else if (direction == "down" && playerTilePos.y != 6 && moved == false)
        {

            targetTilePos = new Vector2Int(playerTilePos.x, playerTilePos.y + 1);
            playerTile = _allTiles[playerTilePos.x, playerTilePos.y];
            targetTile = _allTiles[targetTilePos.x, targetTilePos.y];

            tempPos = playerTile.transform.position;
            playerTile.transform.position = targetTile.transform.position;
            targetTile.transform.position = tempPos;
            playerTilePos.y += 1;
            targetTilePos.y -= 1;
            _allTiles[playerTilePos.x, playerTilePos.y] = playerTile;
            _allTiles[targetTilePos.x, targetTilePos.y] = targetTile;
            playerTile.transform.name = playerTilePos.x + "," + playerTilePos.y;
            targetTile.transform.name = targetTilePos.x + "," + targetTilePos.y;

            myPlayer.transform.GetChild(0).transform.GetChild(0).transform.position = new Vector2(playerTile.transform.position.x + 0.05f, playerTile.transform.position.y - 0.05f);
            moved = true;

        }
        else if (direction == "right" && playerTilePos.x != 4 && moved == false)
        {

            targetTilePos = new Vector2Int(playerTilePos.x + 1, playerTilePos.y);
            playerTile = _allTiles[playerTilePos.x, playerTilePos.y];
            targetTile = _allTiles[targetTilePos.x, targetTilePos.y];

            tempPos = playerTile.transform.position;
            playerTile.transform.position = targetTile.transform.position;
            targetTile.transform.position = tempPos;
            playerTilePos.x += 1;
            targetTilePos.x -= 1;
            _allTiles[playerTilePos.x, playerTilePos.y] = playerTile;
            _allTiles[targetTilePos.x, targetTilePos.y] = targetTile;
            playerTile.transform.name = playerTilePos.x + "," + playerTilePos.y;
            targetTile.transform.name = targetTilePos.x + "," + targetTilePos.y;

            myPlayer.transform.GetChild(0).transform.GetChild(0).transform.position = new Vector2(playerTile.transform.position.x + 0.05f, playerTile.transform.position.y - 0.05f);
            moved = true;
        }


        else if (direction == "left" && playerTilePos.x != 0 && moved == false)
        {

            targetTilePos = new Vector2Int(playerTilePos.x - 1, playerTilePos.y);
            playerTile = _allTiles[playerTilePos.x, playerTilePos.y];
            targetTile = _allTiles[targetTilePos.x, targetTilePos.y];

            tempPos = playerTile.transform.position;
            playerTile.transform.position = targetTile.transform.position;
            targetTile.transform.position = tempPos;
            playerTilePos.x -= 1;
            targetTilePos.x += 1;
            _allTiles[playerTilePos.x, playerTilePos.y] = playerTile;
            _allTiles[targetTilePos.x, targetTilePos.y] = targetTile;
            playerTile.transform.name = playerTilePos.x + "," + playerTilePos.y;
            targetTile.transform.name = targetTilePos.x + "," + targetTilePos.y;

            myPlayer.transform.GetChild(0).transform.GetChild(0).transform.position = new Vector2(playerTile.transform.position.x + 0.05f, playerTile.transform.position.y - 0.05f);
            moved = true;
        }

        moves -= 1;
        Debug.Log(moves);
        playerMoves.text = "" + moves;

    }
    }

