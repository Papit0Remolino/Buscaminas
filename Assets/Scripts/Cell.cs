using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool hasMine;
    public Sprite[] emptytexture;
    public Sprite mineTexture;
    void Start()
    {
        //probabilidad del 15 porciento de que salga mina.
        hasMine = (Random.value < 0.15f); //random.value da un valor entre 0 y 1. Si el valor que sale es < 0.15 hasMine se volverá true;
        Debug.Log(hasMine);
        int x = (int)this.transform.position.x; //el int entre parentesis es para truncar la posicion en caso de que este con decimales
        int y = (int)this.transform.parent.position.y; //parent porque la y la guarda el objecto fila no los paneles de dentro
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
            //TO Do
            //cambiar la textura de la celda
            //descubrir toda el area sin minas alrededor
            //comprobar si el juego ha terminado o no
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
