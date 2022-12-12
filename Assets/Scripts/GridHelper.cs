using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHelper : MonoBehaviour
{
    public static int w = 15;
    public static int h = 15;
    public static int totalMines = 0;
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

    public static void FloodFillUncover(int x, int y, bool[,] visited)
    {
        if (x >= 0 && y >= 0 && x < w && y < h)
        {
            //si ya la hemos visitado
            if (visited[x, y])
            {
                return; //deja de ejecutarse el método
            }
            int adjacentMines = countAdjacentMines(x, y);
            cells[x, y].LoadTexture(adjacentMines);
            if(adjacentMines > 0)
            {
                return;
            }
            //si no, la marcamos como visitada
            visited[x, y] = true;
            //y pasamos a la siguiente celda sin visitar adyacente 
            FloodFillUncover(x - 1, y, visited);
            FloodFillUncover(x + 1, y, visited);
            FloodFillUncover(x, y - 1, visited);
            FloodFillUncover(x, y + 1, visited);
            //MINITAREA
            FloodFillUncover(x - 1, y+1, visited);
            FloodFillUncover(x + 1, y+1, visited);
            FloodFillUncover(x-1, y - 1, visited);
            FloodFillUncover(x+1, y - 1, visited);
        }
    }

    public static bool HasTheGameended()
    {
        foreach(Cell c in cells)
        {
            //si quedan casillas que no sean minas por destapar, todavia no se ha acabado el juego
            if (c.IsCovered() && !c.hasMine)
            {
                return false;
            }
        }
        return true;
    }
}
