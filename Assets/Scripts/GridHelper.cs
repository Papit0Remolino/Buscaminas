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
}
