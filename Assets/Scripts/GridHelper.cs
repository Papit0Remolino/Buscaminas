using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHelper : MonoBehaviour
{
    public static int w = 15;
    public static int h = 15;
    //un array para guardar todas las celdas de nuestro juego
    //al poner la coma en el array le estas diciendo que tiene dos dimensiones [x,y]
    //los static se pueden usar desde otro script
    public static Cell[,] cells = new Cell[w, h]; 

    public static void uncoverAllTheMines()
    {
        foreach (Cell c in cells)
        {
            if (c.hasMine)
            {
                // como el método LadTexture pone una mina si hasMine == true, se le pondra la textura mina;
                c.LoadTexture(0);
            }
        }
    }
    public static bool HasMineAt(int x, int y)
    {
        //if dentro de los limites del array
        if (x >= 0 && y >= 0 && x < w && y < h)
        {
            Cell cell = cells[x, y];
            return cell.hasMine;
        }
        else
        {
            return false;
        }
    }
    public static int countAdjacentMines(int x, int y)
    {
        int count = 0;
        if (HasMineAt(x + 1, y)) count++;
        if (HasMineAt(x - 1, y)) count++;
        if (HasMineAt(x, y + 1)) count++;
        if (HasMineAt(x + 1, y + 1)) count++;
        if (HasMineAt(x - 1, y + 1)) count++;
        if (HasMineAt(x, y - 1)) count++;
        if (HasMineAt(x + 1, y - 1)) count++;
        if (HasMineAt(x - 1, y - 1)) count++;

        return count;

    }
}
