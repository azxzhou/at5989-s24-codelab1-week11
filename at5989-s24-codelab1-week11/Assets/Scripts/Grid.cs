using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{

    public int gridWidth = 7; 
    public int gridHeight = 7;

    public GameObject[,] grid; //[,] to make 2 dimensional

    public GameObject prefab; //this is where you put the prefab

    public static Grid instance;


    void Awake()
    {
        if (instance == null) //if instance doesnt exist, set it to this and dont destroy
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        grid = new GameObject[gridWidth, gridHeight];

        //have to tel grid with prehabs where they are in the grid

        for (int x = 0; x < gridWidth; x++) //dpuble loop arrangements = for grids
        {
            for (int y = 0; y < gridHeight; y++)
            {
                grid[x, y] = Instantiate<GameObject>(prefab); 
                //this populates the game object
                
                grid[x, y].transform.position = new Vector2(x, y); 
                //checks every x y combo and adds capsule

            }
        }

        // Update is called once per frame
        void Update()
        {
            string gridRepresentation = ""; 
            //local variable, only active when update is running
            
            for (int y = 0; y < gridHeight; y++)
            {
                gridRepresentation += "\n"; 
                //add new line to string
                
                for (int x = 0; x < gridWidth; x++)
                {
                    if (grid[x, y] != null)
                    {
                        gridRepresentation += "0"; 
                    }
                    else
                    {
                        gridRepresentation += "_";
                    }
                }
            }
            
            Debug.Log(gridRepresentation);

        }
    }
}
