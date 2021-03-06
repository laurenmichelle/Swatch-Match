﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class grid : MonoBehaviour
{
    public int rows = 7;
    public int columns = 5;
    public float tileSize = 1;
    public bool matchMade = false;
    public GameObject spawnTile;
    private float Myx;
    private float Myy;
    private float startX;
    private float startY;
    playerController _playerController;
    public GameObject[,] allTiles;
    public GameObject empty;
    public int score;
    public TextMeshProUGUI playerSore;
    public GameObject explosion;
    public Color red = Color.red;
    public Color green = Color.green;
    public Color blue = Color.blue;
    public Color purple = Color.magenta;
    public Color yellow = Color.yellow;
    public Color orange = Color.cyan;
    public GameObject PLAYERCONTROLLER;
    public AudioClip [] soundEffects;
    public AudioSource mySound;
    public GameObject blood;
    public GameObject background;



    // Start is called before the first frame update
    void Start()
    {
        startX = -2f;
        startY = 3f;
        Myx = startX;
        Myy = startY;
        allTiles = new GameObject[columns, rows];
        empty.tag = "empty";
        mySound = background.GetComponent<AudioSource>();





}

    // Update is called once per frame
    void LateUpdate()
    {
        CheckForMatches();
        WaitASec();
        MakeGemsFall();
        WaitASec();
        refreshGrid();
        WaitASec();
        RefillGrid();
        WaitASec();

        //gameObject.transform.GetChild(0).transform.GetChild(0).transform.position = new Vector2(GameObject.FindGameObjectWithTag("Player").transform.position.x + 0.05f, GameObject.FindGameObjectWithTag("Player").transform.position.y - 0.05f);

    }
    public void generateGrid()
    {
        bool playerCreated = false;
        for (int col = 0; col < columns; col++)
        {


            for (int row = 0; row < rows; row++)
            {
                if (columns/2 == col && rows/2 == row && playerCreated == false)
                {
                    GameObject myPlayer = spawnTile.GetComponent<spawnTile>().spawnPlayerTile(Myx, Myy, col, row);
                    allTiles[col, row] = myPlayer;
                    //myPlayer.transform.parent = gameObject.transform.GetChild(0).transform;
                    //Debug.Log(col + "," + row);
                    playerCreated = true;

                }
                else
                {
                    GameObject myTile = spawnTile.GetComponent<spawnTile>().makeRandomTile(Myx, Myy, col, row);
                    allTiles[col, row] = myTile;
                }
                Myy -= 1;

               
            }
            Myy = startY;
            Myx += 1;
        }
       

    }

   public void refreshGrid()
    {
        startX = -2f;
        startY = 3f;
        Myx = startX;
        Myy = startY;
        //Debug.Log("REFRESHING GRID");
        for (int col=0; col<columns; col++)
        {
            for(int row=0; row<rows; row++)
            {
                if (allTiles[col, row] == null)
                {

                    //Debug.Log("GameObject is null");
                }
                else if ( allTiles[col,row]!=null)
                {
                    //Debug.Log("Moving object ");
                    allTiles[col, row].transform.parent = gameObject.transform;
                    allTiles[col, row].transform.position = new Vector2(Myx, Myy);
                    //Debug.Log("We found a regular object!");

                    if (allTiles[col,row].tag == "Player")

                    {
                        //Debug.Log("We found a player!");
                        allTiles[col, row].transform.parent = gameObject.transform.GetChild(0).transform;
                        allTiles[col, row].transform.position = new Vector2(Myx, Myy);
                        //Debug.Log(_playerController.GetComponent<playerController>().playerTile.Equals(null));
                        //_playerController.GetComponent<playerController>().playerTile = allTiles[col, row];


                        //gameObject.transform.GetChild(0).transform.GetChild(0).transform.position = new Vector2(allTiles[col, row].transform.position.x + 0.05f, allTiles[col, row].transform.position.y - 0.05f);
                        //Debug.Log("HELLO LAUREN:" +gameObject.transform.GetChild(0).transform.GetChild(0).name);
                    }


                }
                Myy -= 1;
            }
            Myy = startY;
            Myx += 1;
        }
        //WaitASec();

        //CALLING FUNCTION
        //RefillGrid();
        //CALLING FUNCTION

        //CheckForMatches();



    }


    public int CheckColumn (GameObject currentCell, int col, int row)
    {
        //int numMatches = 1;
        List<GameObject> matches = new List<GameObject>();
        List<Vector2Int> matchPos = new List<Vector2Int>();
        matchPos.Add(new Vector2Int(col, row));
        for (int tempRow = row + 1; tempRow < rows; tempRow++)
        {
            if (allTiles[col, tempRow] != null)
            {
                GameObject tempCell = allTiles[col, tempRow];
                Vector2Int tempCellPos = new Vector2Int(col, tempRow);


                if (tempCell.GetComponent<SpriteRenderer>().sprite.name == currentCell.GetComponent<SpriteRenderer>().sprite.name)
                {
                    matches.Add(tempCell);
                    matchPos.Add(tempCellPos);

                }
                else
                {

                    break;
                }
            }

        }
        //Debug.Log("The Matches list has:" + matches.Count);
        if (matches.Count >= 2)
        {
            matches.Add(currentCell);
            //_playerController.GetComponent<playerController>().moves = 6;
            //_playerController.GetComponent<playerController>().playerMoves.text = "" + _playerController.GetComponent<playerController>().moves;
            for ( int i=0; i<matches.Count; i++)
            {
                //matches[i].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
                GameObject newExplosion = Instantiate(explosion, allTiles[matchPos[i].x, matchPos[i].y].transform.position, Quaternion.identity);
                WaitASec();
               
                allTiles[matchPos[i].x, matchPos[i].y] = null;
                Destroy(matches[i]);
                int arrayInt = Random.Range(0, soundEffects.Length);

                mySound.PlayOneShot(soundEffects[arrayInt]);



                //matches[i].GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 0f);



                //GameObject thisTile = matches[i];

                //thisTile = null;
            }
        }

        //Debug.Log("Matched:" + numMatches);
        return matches.Count;

    }
    public IEnumerator WaitASec()
    {
        yield return new WaitForSeconds(2);

    }
    public int CheckRow(GameObject currentCell, int col, int row)
    {
        List<GameObject> matches2 = new List<GameObject>();
        List<Vector2Int> matchPos2 = new List<Vector2Int>();
        matchPos2.Add(new Vector2Int(col, row));
        for (int tempCol = col + 1; tempCol < columns; tempCol++)
        {
            if (allTiles[tempCol, row] != null)
            {
                GameObject tempCell = allTiles[tempCol, row];

                Vector2Int tempCellPos = new Vector2Int(tempCol, row);


                if (tempCell.GetComponent<SpriteRenderer>().sprite.name == currentCell.GetComponent<SpriteRenderer>().sprite.name)
                {
                    matches2.Add(tempCell);
                    matchPos2.Add(tempCellPos);

                }
                else
                {

                    break;

                }
            }


        }
        //Debug.Log("The Matches list has:" + matches2.Count);
        if (matches2.Count >= 2)
        {
            matches2.Add(currentCell);

            //matchMade = true;

            //_playerController.GetComponent<playerController>().moves = 6;
            //_playerController.GetComponent<playerController>().playerMoves.text = "" + _playerController.GetComponent<playerController>().moves;
            for (int i = 0; i < matches2.Count; i++)
            {
                //matches2[i].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
                GameObject newExplosion = Instantiate(explosion, allTiles[matchPos2[i].x, matchPos2[i].y].transform.position, Quaternion.identity);
                WaitASec();

                //     if (_playerController.GetComponent<playerController>().player1stMove == true)
                //{
                //    GameObject newBlood = Instantiate(blood, new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f)), Quaternion.identity);
                //    List<GameObject> bloodList = new List<GameObject>();

                //    bloodList.Add(newBlood);
                //    if (bloodList.Count > 10)
                //    {
                //        for (int m = 0; m < 8; m++)
                //        {3
                //            Destroy(bloodList[m]);
                //        }
                //    }
                //}


                allTiles[matchPos2[i].x, matchPos2[i].y] = null;
                    Destroy(matches2[i]);
                int arrayInt = Random.Range(0, soundEffects.Length);

                mySound.PlayOneShot(soundEffects[arrayInt]);



            }
           




            //matches2[i].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);


        }





        //Debug.Log("Matched:" + numMatches);

        return matches2.Count;

    }

    public bool CheckForMatches()

    {
        GameObject currentCell;
        int countCol =0;
        int countRow = 0;
        //int oldCountCol;
        //int oldCountRow;

        bool playerFoundAMatch = false;
        for (int col = 0; col<columns; col++)
        {
            for(int row =0; row<rows; row++)

            {
                countCol = 0;
                countRow = 0;
                if (allTiles[col, row] != null)
                {
                    currentCell = allTiles[col, row];

                    //oldCountCol = countCol;
                    //oldCountRow = countRow;

                    countCol = CheckColumn(currentCell, col, row);
                    countRow = CheckRow(currentCell, col, row);





                    if (countCol >= 3 || countRow >= 3)
                    {
                        playerFoundAMatch = true;

                        score += countCol + countRow;
                        playerSore.text = "Death Count:" + score;


                       //Destroy(newExplosion);

                        //Debug.Log("CountCol:" + countCol);
                        //Debug.Log("CountRow:" + countRow);


                    }

                }

            }
        }

        //CALLING FUNCTION
        //WaitASec();
        //MakeGemsFall();

        return playerFoundAMatch;
    }
    public void MakeGemsFall()
    {
        int distance = 0;

        for (int col = 4; col >= 0; col--)
        {

            for (int row = 5; row >= 0; row--)
            {
                //Debug.Log(col + "," + row);
                //if(allTiles[col,row]!=null){
                GameObject fallingToken = allTiles[col, row];
                int belowRow = row + 1;
                distance = 0;
                //Debug.Log("Below Row before While:"+ belowRow);
                while (allTiles[col, belowRow] == null && belowRow <= 6)
                {
                    distance++;
                    belowRow++;

                    if (belowRow == 7)
                    {
                        break;
                    }

                    //Debug.Log("My distance is in while:" + distance);
                    //Debug.Log("Below Row in While:" + belowRow);
                }
                //Debug.Log("My distance is out after while:" + distance);

                if (distance > 0)
                { 

                    allTiles[col, row+distance] = fallingToken;
                    //Debug.Log(allTiles[col, row + distance]);

                    //if (allTiles[col,row+distance]!=null && allTiles[col,row+distance].tag == "Player")
                    //{

                    //    gameObject.transform.GetChild(0).transform.GetChild(0).transform.position = new Vector2(allTiles[col, row + distance].transform.position.x + 0.05f, allTiles[col, row + distance].transform.position.y - 0.05f);

                    //    //Debug.Log("the tag is not the issue");

                    //}
                    allTiles[col, row] = null;
                    refreshGrid();
                    
                    //GameObject targetToken = allTiles[col, row + distance];
                    //Vector2Int fallingTokenPos = new Vector2Int(col, row);
                    //Vector2Int targetTokenPos = new Vector2Int(col, row + distance);
                    //GameObject tempPosition = targetToken;
                    //fallingToken.transform.position = targetToken.transform.position;
                    //targetToken.transform.position = tempPosition.transform.position;
                    //fallingTokenPos.y += distance;
                    //targetTokenPos.y -= distance;
                    //allTiles[targetTokenPos.x, targetTokenPos.y] = targetToken;
                    //allTiles[fallingTokenPos.x, fallingTokenPos.y] = fallingToken;
                    //fallingToken.transform.name = fallingTokenPos.x + "," + fallingTokenPos.y;
                    //targetToken.transform.name = targetTokenPos.x + "," + targetTokenPos.y;
                }

            }
        }
        WaitASec();
    }

   public void RefillGrid()
    {
        startX = -2f;
        startY = 3f;
        Myx = startX;
        Myy = startY;
        for (int col = 0; col < columns; col++)
        {
            for (int row = 0; row < rows; row++)
            {
                if (allTiles[col, row] == null)
                {

                    GameObject myTile = spawnTile.GetComponent<spawnTile>().makeNewTile(col, row);
                    //myTile.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
                    allTiles[col, row] = myTile;
                    myTile.tag = "newTile";
                    //Debug.Log(Equals(allTiles[col,row],null));
                }

            }
                Myy -= 1;
            }
            Myy = startY;
            Myx += 1;


        }
    }


        //refreshGrid();
    

    //public void MakeGemsFall()
    //{
    ////looping throught the grid backwards
    //for (int col = columns-1; col>=0; col--)
    //{
    //    for(int row = rows - 1; row <= 0; row--)
    //    {
    //        GameObject currentToken = tokens[col, row];
    //        //checks if the row below it is null and if so it needs to fall
    //        int distance = 0;


    //        GameObject destination = tokens[col, row + distance];


    //        do
    //        {
    //            distance++;
    //            GameObject destination = tokens[col, row + distance];
    //        }

    //            while(destination == null)
    //            {
    //            //setting old position to null 
    //            tokens[col, row] = null;
    //            //add in an animation
    //            tokens[col, row + distance] = currentToken;
    //            }
    //        }
    //    }
    //}
    //public void MakeGemsFall()
    //{

    ////Debug.Log("HELLO MAKE GEMS FALL");
    //int distance;
    //for (int col = columns-1; col>=0; col--)
    //{
    //    for (int row = rows - 2; row >= 0; row--)
    //    {
    //        if(allTiles[col, row].GetComponent<SpriteRenderer>().color != new Color(0f,0f,0f,0f) && allTiles[col, row+1].GetComponent<SpriteRenderer>().color == new Color(0f, 0f, 0f, 0f))
    //        {

    //            //int fallingRow = row+1;
    //            int fallingRow = row + 1;
    //            GameObject fallingToken = allTiles[col, row];
    //            GameObject tempPosition;
    //            GameObject targetToken;
    //            distance = 1;
    //            while (allTiles[col, fallingRow].GetComponent<SpriteRenderer>().color == new Color(0f, 0f, 0f, 0f))
    //            {
    //                fallingRow += 1;
    //                distance += 1;
    //                if (fallingRow == 6)
    //                {
    //                    break;
    //                }

    //            }
    //            //setting the falling token to the position of the bottom most deleted gem's position
    //            targetToken = allTiles[col, row + distance];
    //            Vector2Int fallingTokenPos = new Vector2Int(col, row);
    //            Vector2Int targetTokenPos = new Vector2Int(col, row + distance);
    //            tempPosition = targetToken;

    //            fallingToken.transform.position = targetToken.transform.position;
    //            targetToken.transform.position = tempPosition.transform.position;
    //            fallingTokenPos.y += distance;
    //            targetTokenPos.y -= distance;
    //            allTiles[targetTokenPos.x, targetTokenPos.y] = targetToken;
    //            allTiles[fallingTokenPos.x, fallingTokenPos.y] = fallingToken;
    //            fallingToken.transform.name = fallingTokenPos.x + "," + fallingTokenPos.y;
    //            targetToken.transform.name = targetTokenPos.x + "," + targetTokenPos.y;










    //        }







    //    }




    //}
    //}



