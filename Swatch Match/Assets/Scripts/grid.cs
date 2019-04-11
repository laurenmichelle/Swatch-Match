using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grid : MonoBehaviour
{
    public int rows = 7;
    public int columns = 5;
    public float tileSize = 1;
    public GameObject spawnTile;
    private float Myx;
    private float Myy;
    private float startX;
    private float startY;
    public GameObject[,] allTiles;
   

    // Start is called before the first frame update
    void Start()
    {
        startX = -2f;
        startY = 3f;
        Myx = startX;
        Myy = startY;
        allTiles = new GameObject[columns, rows];
        //generateGrid(); 


    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void generateGrid()
    {
        bool playerCreated = false;
        for (int col = 0; col < columns; col++)
        {
            //spawnTile.GetComponent<spawnTile>().makeRandomTile(Myx,Myy);

            for (int row = 0; row < rows; row++)
            {
                if (columns/2 == col && rows/2 == row && playerCreated == false)
                {
                    GameObject myPlayer = spawnTile.GetComponent<spawnTile>().spawnPlayerTile(Myx, Myy, col, row);
                    allTiles[col, row] = myPlayer;
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

        //Debug.Log("Finished making grid");
        //for (int col = 0; col < columns; col++)
        //{
        //    for (int row = 0; row < rows; row++)
        //    {
        //        Debug.Log(allTiles[col, row]);
        //    }
        //}
    }

   


    //int CheckColumn (GameObject currentCell, int col, int row)
    //{
    //    int numMatches = 1;
    //    List<GameObject> matches = new List<GameObject>;
    //    for (int tempRow = row + 1; tempRow < rows; row++)
    //    {
    //        GameObject tempCell = tokens[col, tempRow];
    //        if(tempCell.color = currentCell.color)
    //        {
    //            numMatches.Add(tempCell);
    //        }
    //        else
    //        {
    //            break;
    //        }


    //    }
    //    if (matches.Count > 3)
    //    {
    //        //do matching stuff 
    //    }

    //}

    //private void CheckForMatches()

    //{
    //    GameObject currentCell;
    //    for (int col = 0; col<columns; col++)
    //    {
    //        for(int row =0; row<rows; row++)
    //        {
    //            GameObject currentCell = tokens[col, row];
    //            int count = CheckColumn(currentCell, col, row);
    //        }
    //    }
    //}

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
}

