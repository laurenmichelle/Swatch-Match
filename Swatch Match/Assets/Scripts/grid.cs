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
    // Start is called before the first frame update
    void Start()
    {
        startX = -2f;
        startY = 3f;
        Myx = startX;
        Myy = startY;
        generateGrid(); 

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void generateGrid()
    {
        bool playerCreated = false;
        for (int col = 0; col < columns; col++)
        {
            //spawnTile.GetComponent<spawnTile>().makeRandomTile(Myx,Myy);

            for (int row = 0; row < rows; row++)
            {
                if (col == 2 && row == 3 && playerCreated == false)
                {
                    spawnTile.GetComponent<spawnTile>().spawnPlayerTile(Myx, Myy );
                    playerCreated = true;
                }
                else
                {
                    spawnTile.GetComponent<spawnTile>().makeRandomTile(Myx, Myy );
                }
                Myy -= 1;

               
            }
            Myy = startY;
            Myx += 1;
        }
    }
}
