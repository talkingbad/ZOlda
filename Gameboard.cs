using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;

public class Gameboard : MonoBehaviour {

    // TODO remember to change under rock to stairs
    // after rock is moved
    // TODO change to gem and then stump after the bush
    // TODO the same for boom, bomb, bow , vace

    // types of objects hills, trees, bush, house, boom
    //bomb, stone, bow, vace, gem, stairs, door, chest

    public string[,] gameObjects = new string[26, 19];


	// Use this for initialization
	void Start () {

        AddYRowXRange(0, 0, 25, "Hill");
        AddYRowXRange(18, 0, 25, "Hill");
        AddYRowXRange(3, 0, 7, "Hill");
        AddYRowXRange(5, 0, 6, "Hill");
        AddYRowXRange(4, 0, 7, "Hill");
        AddYRowXRange(5, 0, 6, "Hill");
        AddYRowXRange(14, 0, 4, "Hill");
        AddYRowXRange(15, 0, 4, "Hill");
        AddYRowXRange(5, 0, 6, "Hill");
        AddYRowXRange(15, 7, 11, "Hill");
        AddYRowXRange(14, 7, 10, "Hill");
        AddYRowXRange(12, 15, 22, "Hill");
        AddYRowXRange(13, 15, 22, "Hill");

        AddxColYRange(0, 0, 18, "Hill");
        AddxColYRange(25, 0, 18, "Hill");
        AddxColYRange(10, 0, 14, "Hill");
        AddxColYRange(12, 0, 14, "Hill");

        AddYRowXRange(17, 14, 17, "Tree");
        AddYRowXRange(16, 14, 17, "Tree");
        AddYRowXRange(15, 19, 20, "Tree");
        AddYRowXRange(14, 19, 20, "Tree");

        AddYRowXRange(17, 19, 22, "Bush");
        AddYRowXRange(2, 3, 5, "Bush");

        AddYRowXRange(5, 18, 20, "House");
        AddYRowXRange(4, 18, 20, "House");
        AddxColYRange(18, 3, 3, "House");
        AddxColYRange(20, 3, 3, "House");

        // Place single game objects
        gameObjects[24, 1] = "bow";
        gameObjects[1, 17] = "bomb";
        gameObjects[8, 11] = "boomerang";
        gameObjects[2, 1] = "stone";
        gameObjects[19, 3] = "Door";


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void AddYRowXRange(int yRow, int xStart, int xEnd, string gOName)
    {
        for(int i = xStart; i <= xEnd; i++)
        {
            gameObjects[i, yRow] = gOName;
        }
    }

    void AddxColYRange(int xColumn, int yStart, int yEnd, string gOName)
    {
        for (int i = yStart; i <= yEnd; i++)
        {
            gameObjects[xColumn, i] = gOName;
        }
    }

    public bool isValidSpace(float x, float y, float horzMove, float vertMove)
    {
        x = horzMove < 0 ? x + 1 : x;
        y = vertMove < 0 ? y + 1 : x;

        x = (float)Math.Floor(Convert.ToDouble(x));
        y = (float)Math.Floor(Convert.ToDouble(y));

        if(gameObjects [(int)x, (int)y] == null)
        {
            return true;
        } else
        {
            return false;
        }


    }



}
