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
   

    void Start()
    {
        startPosition = new Vector2(0f, 0f);
        spaceBetween = 3f;


    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject makeRandomTile(float xPosition, float yPosition, int x, int y)
    {
        int arrayIndex = Random.Range(0,tileColorSprites.Length);
        Sprite colorSprite = tileColorSprites[arrayIndex];
        string _tileColorName = x + "," + y;


        GameObject newTile = Instantiate(tilesPrefab);
        newTile.transform.parent = myGrid.transform;
        newTile.name = _tileColorName;
        newTile.GetComponent<SpriteRenderer>().sprite = colorSprite;
        newTile.transform.position = new Vector2(xPosition,yPosition);
        return newTile;



    }
    public GameObject makeNewTile(int x, int y)
    {
        int arrayIndex = Random.Range(0, tileColorSprites.Length);
        Sprite colorSprite = tileColorSprites[arrayIndex];
        string _tileColorName = x + "," + y;

        GameObject newTile = Instantiate(tilesPrefab);
        newTile.transform.parent = myGrid.transform;
        newTile.name = _tileColorName;
        newTile.GetComponent<SpriteRenderer>().sprite = colorSprite;

        return newTile;



    }

    public GameObject spawnPlayerTile(float xPosition, float yPosition, int x, int y)
    {

        GameObject playerTile = Instantiate(tilesPrefab);
        Sprite playerTilesprite = whiteCircleSprite;
        string playerName = x +  "," + y;

        playerTile.transform.parent = player.transform;
        playerTile.tag = "Player";
        playerTile.name = playerName;
        playerTile.GetComponent<SpriteRenderer>().sprite = playerTilesprite;
        playerTile.transform.position = new Vector2(xPosition, yPosition);

        return playerTile;

    }
}
