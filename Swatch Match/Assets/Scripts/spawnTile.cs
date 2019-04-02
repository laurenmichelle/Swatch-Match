using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnTile : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tilesPrefab;
    public Sprite[] tileColorSprites;
    public Sprite whiteCircleSprite;
    public float spaceBetween = 0;
    public Vector2 startPosition;
    public GameObject myGrid;
    public GameObject player;
    public GameObject [,] allTiles;
    void Start()
    {
        startPosition = new Vector2(0f, 0f);
        spaceBetween = 3f;
        allTiles = new GameObject[myGrid.GetComponent<grid>().columns, myGrid.GetComponent<grid>().rows];

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void makeRandomTile(float xPosition, float yPosition)
    {
        int arrayIndex = Random.Range(0,tileColorSprites.Length);
        Sprite colorSprite = tileColorSprites[arrayIndex];
        string _tileColorName = xPosition + "," + yPosition;

        GameObject newTile = Instantiate(tilesPrefab);
        newTile.transform.parent = myGrid.transform;
        newTile.name = _tileColorName;
        newTile.GetComponent<SpriteRenderer>().sprite = colorSprite;
        newTile.transform.position = new Vector2(xPosition,yPosition);
        allTiles[xPosition, yPosition] = newTile;


    }

    public void spawnPlayerTile(float xPosition, float yPosition)
    {

        GameObject playerTile = Instantiate(tilesPrefab,);
        Sprite playerTilesprite = whiteCircleSprite;
        string playerName = xPosition +  "," + yPosition;

        playerTile.transform.parent = player.transform;
        playerTile.name = playerName;
        playerTile.GetComponent<SpriteRenderer>().sprite = playerTilesprite;
        playerTile.transform.position = new Vector2(xPosition, yPosition);


    }
}
