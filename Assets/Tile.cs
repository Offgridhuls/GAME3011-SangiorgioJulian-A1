using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    public Vector2Int index;

    public int[,] tileArray;

    public Material baseMaterial;

    public int row;
    public int col;
    public int materialCounter;

    public bool isScanned;

    void Start()
    {
        tileArray = new int[TileSpawner.instance.gridLength, TileSpawner.instance.gridWidth];
        isScanned = false;
        //Debug.Log(index);
    }

    void Update()
    {
        if (materialCounter <= 0)
        {
            materialCounter = 0;
        }
        if (isScanned == true)
        {
            if (materialCounter == 1000)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.black;
            }
            if (materialCounter == 2000)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.cyan;
            }
            if (materialCounter == 3000)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.blue;
            }
            if (materialCounter == 4000)
            {
                gameObject.GetComponent<Renderer>().material.color = Color.magenta;
            }
        }
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if(GameManager.instance._state == GameManager.State.Scan && GameManager.instance.scanCounter > 0)
        {
            for (int x = index.x - 2; x < index.x + 3; x++)
            {
                for (int y = index.y - 2; y < index.y + 3; y++)
                {
                    if (!(x < 0 || x > TileSpawner.instance.gridLength - 1 ||
                          y < 0 || y > TileSpawner.instance.gridWidth - 1))
                    {
                        if (TileSpawner.instance.tiles[x, y].materialCounter == 1000)
                        {
                            TileSpawner.instance.tiles[x, y].GetComponent<Renderer>().material.color = Color.black;
                            TileSpawner.instance.tiles[x, y].isScanned = true;
                        }
                        if (TileSpawner.instance.tiles[x, y].materialCounter == 2000)
                        {
                            TileSpawner.instance.tiles[x, y].GetComponent<Renderer>().material.color = Color.cyan;
                            TileSpawner.instance.tiles[x, y].isScanned = true;
                        }
                        if (TileSpawner.instance.tiles[x, y].materialCounter == 3000)
                        {
                            TileSpawner.instance.tiles[x, y].GetComponent<Renderer>().material.color = Color.blue;
                            TileSpawner.instance.tiles[x, y].isScanned = true;
                        }
                        if (TileSpawner.instance.tiles[x, y].materialCounter == 4000)
                        {
                            TileSpawner.instance.tiles[x, y].GetComponent<Renderer>().material.color = Color.magenta;
                            TileSpawner.instance.tiles[x, y].isScanned = true;
                        }
                    }
                }
            }

            GameManager.instance.scanCounter -= 1;
        }
        else if (GameManager.instance._state == GameManager.State.Extract && GameManager.instance.extractCounter > 0)
        {
            for (int x = index.x - 2; x < index.x + 3; x++)
            {
                for (int y = index.y - 2; y < index.y + 3; y++)
                {
                    if (!(x < 0 || x > TileSpawner.instance.gridLength - 1 ||
                          y < 0 || y > TileSpawner.instance.gridWidth - 1))
                    {
                        TileSpawner.instance.tiles[x, y].Collect();
                    }
                }
            }

            GameManager.instance.extractCounter -= 1;
        }
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        for (int x = index.x - 2; x < index.x + 3; x++)
        {
            for (int y = index.y - 2; y < index.y + 3; y++)
            {
                if (!(x < 0 || x > TileSpawner.instance.gridLength - 1 || 
                      y < 0 || y > TileSpawner.instance.gridWidth - 1))
                {
                    TileSpawner.instance.tiles[x, y].GetComponent<Renderer>().material.color = new Color(
                        TileSpawner.instance.tiles[x, y].GetComponent<Renderer>().material.color.r,
                        TileSpawner.instance.tiles[x, y].GetComponent<Renderer>().material.color.g,
                        TileSpawner.instance.tiles[x, y].GetComponent<Renderer>().material.color.b, .5f);
                }
            }
        }
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        for (int x = index.x - 2; x < index.x + 3; x++)
        {
            for (int y = index.y - 2; y < index.y + 3; y++)
            {
                if (!(x < 0 || x > TileSpawner.instance.gridLength - 1 ||
                      y < 0 || y > TileSpawner.instance.gridWidth - 1))
                {
                    TileSpawner.instance.tiles[x, y].GetComponent<Renderer>().material.color = new Color(
                        TileSpawner.instance.tiles[x, y].GetComponent<Renderer>().material.color.r,
                        TileSpawner.instance.tiles[x, y].GetComponent<Renderer>().material.color.g,
                        TileSpawner.instance.tiles[x, y].GetComponent<Renderer>().material.color.b, 1.0f);
                }
            }
        }
    }

    void Collect()
    {
        GameManager.instance.totalMaterial += materialCounter;
        materialCounter = materialCounter - 1000;
    }
}
