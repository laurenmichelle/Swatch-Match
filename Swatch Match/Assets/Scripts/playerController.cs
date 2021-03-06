﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class playerController : MonoBehaviour
{

    grid mygrid;
    public GameObject myPlayer;
    public int moves;
    public char column;
    public char row;
    private GameObject[,] _allTiles;
    public GameObject playerTile;
    private GameObject targetTile;
    public TextMeshProUGUI playerMoves;

    //Positions of GameObjects within the array
    private Vector2Int playerTilePos ;
    private Vector2Int targetTilePos;
    public bool player1stMove = false;
    public GameObject blood;
    

    //Actual Spaces where Tiles should be in the game world
    private Vector2 tempPos;

    // Start is called before the first frame update
    void Start()
    {
        mygrid = FindObjectOfType<grid>();
        mygrid.GetComponent<grid>().generateGrid();
        _allTiles = mygrid.GetComponent<grid>().allTiles;

        playerTilePos = new Vector2Int(2, 3);
        playerTile = _allTiles[playerTilePos.x, playerTilePos.y];
        //myPlayer.transform.GetChild(0).transform.GetChild(0).transform.position = new Vector2(playerTile.transform.position.x + 0.05f, playerTile.transform.position.y - 0.05f);
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

        if (player1stMove == false)
        {
            mygrid.GetComponent<grid>().score = 0;
        }
        if (moves == 0)
        {
            SceneManager.LoadScene(1);
        }
        //myPlayer.transform.GetChild(0).transform.GetChild(0).transform.position = new Vector2(playerTile.transform.position.x + 0.05f, playerTile.transform.position.y - 0.05f);
    }

    private Vector2Int FindPlayer(Vector2Int oldPosition)
    {
        mygrid.WaitASec();
        mygrid.WaitASec();

        Vector2Int playerPosInArray = new Vector2Int (0,0);
        for (int col=0; col<4; col++)
        {
            for(int rows=0; rows<6; rows++)
            {
                if(_allTiles[col,rows].tag == "Player")
                {
                    Debug.Log("FOUND PLAYER POSITION:" +col +"," +rows);
                    
                    playerPosInArray = new Vector2Int(col, rows);

                    return playerPosInArray;

                }


            }
        }


        return oldPosition;

    }
    private void Swap(string direction)
    {
        bool moved = false;
        player1stMove = true;
        mygrid.WaitASec();
        Vector2Int oldPlayerPos = playerTilePos;
        playerTilePos = FindPlayer(oldPlayerPos);
        if(playerTilePos == new Vector2Int(0, 0))
        {
            playerTilePos = FindPlayer(playerTilePos);
        }
        if (direction == "up" && playerTilePos.y != 0 && moved == false)
        {
            // Getting the position of the target tile
            //playerTilePos = FindPlayer();
            targetTilePos = new Vector2Int(playerTilePos.x, playerTilePos.y - 1);
            // Getting the array position of the player
            playerTile = _allTiles[playerTilePos.x, playerTilePos.y];
            // Getting the array potiion of the target tile
            targetTile = _allTiles[targetTilePos.x, targetTilePos.y];
            //Setting the temporary position to the old position of the player
            tempPos = playerTile.transform.position;
            //Setting the new position of the player to be the Target gem's old position
            playerTile.transform.position = targetTile.transform.position;
            //Setting the new position of the target tile to be the old position of the player
            targetTile.transform.position = tempPos;
            // reseting the array position of the player and target tile
            playerTilePos.y -= 1;
            targetTilePos.y += 1;
            //reseting the gameobjects in the array 
            _allTiles[playerTilePos.x, playerTilePos.y] = playerTile;
            _allTiles[targetTilePos.x, targetTilePos.y] = targetTile;
            //renaming the gameobjects to their correct positions in the array
            playerTile.transform.name = playerTilePos.x + "," + playerTilePos.y;
            targetTile.transform.name = targetTilePos.x + "," + targetTilePos.y;
            //moving the text of the object
            //myPlayer.transform.GetChild(0).transform.GetChild(0).transform.position = new Vector2(playerTile.transform.position.x + 0.05f, playerTile.transform.position.y - 0.05f);
            //making moved to be true to exit the if statement
            moved = true;
            //mygrid.CheckForMatches();

        }
        else if (direction == "down" && playerTilePos.y != 6 && moved == false)
        {

            //playerTilePos = FindPlayer();
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

            //myPlayer.transform.GetChild(0).transform.GetChild(0).transform.position = new Vector2(playerTile.transform.position.x + 0.05f, playerTile.transform.position.y - 0.05f);
            moved = true;
            //mygrid.CheckForMatches();

        }
        else if (direction == "right" && playerTilePos.x != 4 && moved == false)
        {
            //playerTilePos = FindPlayer();
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

            //myPlayer.transform.GetChild(0).transform.GetChild(0).transform.position = new Vector2(playerTile.transform.position.x + 0.05f, playerTile.transform.position.y - 0.05f);
            moved = true;
            //mygrid.CheckForMatches();
        }


        else if (direction == "left" && playerTilePos.x != 0 && moved == false)
        {
            //playerTilePos = FindPlayer();
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

            //myPlayer.transform.GetChild(0).transform.GetChild(0).transform.position = new Vector2(playerTile.transform.position.x + 0.05f, playerTile.transform.position.y - 0.05f);
            moved = true;
            //mygrid.CheckForMatches();
        }
        bool playerFoundAMatch = mygrid.CheckForMatches();

        if (playerFoundAMatch == true)
        {
           
            moves = 6;
            playerMoves.text = "" + moves;
            GameObject newBlood = Instantiate(blood, new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f)), Quaternion.identity);

        }

        else
        {
            moves -= 1;
            //Debug.Log(moves);
            playerMoves.text = "" + moves;

        }
        playerFoundAMatch = false;


        //playerTilePos = FindPlayer();
        //positionofPlayer(playerTile);
    }

    //public GameObject positionofPlayer(GameObject playerTile) 
    //{
    //    return playerTile;
    //}
}

