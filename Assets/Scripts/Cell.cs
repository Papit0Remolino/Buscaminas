using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cell : MonoBehaviour
{
    public bool hasMine;
    public Sprite[] emptytexture;
    public Sprite mineTexture;
    int x, y;
    [SerializeField] TextMeshProUGUI minesText;
    void Start()
    {
        //probabilidad del 15 porciento de que salga mina.
        hasMine = (Random.Range(0,100) < GetComponentInParent<MineChance>().mineChance); //random.value da un valor entre 0 y 1. Si el valor que sale es < 0.15 hasMine se volverá true;
        if (hasMine == true)
        {
            GridHelper.totalMines++;
        }
        minesText.text = "Total mines: " + GridHelper.totalMines.ToString();
        x = (int)this.transform.position.x; //el int entre parentesis es para truncar la posicion en caso de que este con decimales
        y = (int)this.transform.parent.position.y; //parent porque la y la guarda el objecto fila no los paneles de dentro
        //en la matriz posicion(la de este objeto) metele el gameobject donde esta este código(this);
        GridHelper.cells[x, y] = this;

    }
    void Update()
    {
        
    }
    public bool IsCovered()
    {
        return GetComponent<SpriteRenderer>().sprite.texture.name == "Idle";
    }
    private void OnMouseUpAsButton()
    {
        if (hasMine)
        {
            GridHelper.uncoverAllTheMines();
        }
        else
        {
            LoadTexture(GridHelper.CountAdjacentMines(x, y));
            GridHelper.FloodFillUncover(x, y, new bool[GridHelper.w, GridHelper.h]);
            if (GridHelper.HasTheGameended())
            {
                Debug.Log("ganas");
            }
        }
    }
    public void LoadTexture(int adjacentCount) //cuenta las minas adyacentes para calcular el numero a poner al clicar
    {
        if (hasMine)
        {
            GetComponent<SpriteRenderer>().sprite = mineTexture;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = emptytexture[adjacentCount];
        }
    }

}
