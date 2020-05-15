using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// http://codesaying.com/unity-parse-excel-in-unity3d/

public class CalendarReader : MonoBehaviour
{
    /// <summary>
    /// The csv file can be dragged throughthe inspector.
    /// </summary>
    public TextAsset csvFile;

    /// <summary>
    /// The grid in which the CSV File would be parsed.
    /// </summary>
    public static string[,] grid;

    // Start is called before the first frame update
    void Start()
    {
        grid = getCSVGrid(csvFile.text);
        getValueAtIndex(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// splits a CSV file into a 2D string array
    /// </summary>
    /// <returns> 2 day array of the csv file.</returns>
    /// <param name="csvText">the CSV data as string</param>
    static public string[,] getCSVGrid(string csvText)
    {
        //split the data on split line character
        string[] lines = csvText.Split("\n"[0]);

        // find the max number of columns
        int totalColumns = 0;
        for (int i = 0; i < lines.Length; i++)
        {
            string[] row = lines[i].Split(',');
            totalColumns = Mathf.Max(totalColumns, row.Length);
        }

        // creates new 2D string grid to output to
        string[,] outputGrid = new string[totalColumns + 1, lines.Length + 1];
        for (int y = 0; y < lines.Length; y++)
        {
            string[] row = lines[y].Split(',');
            for (int x = 0; x < row.Length; x++)
            {
                outputGrid[x, y] = row[x];
            }
        }
        DisplayGrid(outputGrid);
        return outputGrid;
    }

    static public void DisplayGrid(string[,] grid)
    {
        string textOutput = "";
        for (int y = 0; y < grid.GetUpperBound(1); y++)
        {
            for (int x = 0; x < grid.GetUpperBound(0); x++)
            {

                textOutput += grid[x, y];
                textOutput += ",";
            }
            textOutput += "\n";
        }
    }

    void getValueAtIndex(int row, int col)
    {
        Debug.Log(grid[row, col]);
    }
}
