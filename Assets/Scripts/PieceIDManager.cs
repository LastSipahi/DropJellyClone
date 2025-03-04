using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceIDManager : MonoBehaviour
{
    /*
     single         [0]
    Half_Half       [0,1]
    HalfQuarterRight|0|[1]
                    |0|[2]
    HalfQuarterLeft [0]|1|
                    [2]|1|
    All_Quarter     [0][1]
                    [2][3]
    */
    public enum PuzzlePieces 
    { 
        Single,
        Half_Half,
        Half_Quarter_Right,
        Half_Quarter_Left,
        All_Quarter
    }
    public PuzzlePieces Pieces = new PuzzlePieces();

    public enum Colors
    { 
        Blue,
        Green,
        Purple,
        Red,
        Yellow
    }
    public Colors colors = new Colors();
    public int[] ColorIndex;
    [SerializeField] Material[] ColorMaterials; //B,G,P,R,Y

    private void OnEnable()
    {
        LoadPieceID();
    }
    void LoadPieceID()
    {
        if (Pieces == PuzzlePieces.Single)
        {
            transform.GetChild(0).GetComponent<Renderer>().material = ColorMaterials[ColorIndex[0]];
        }
        else if (Pieces == PuzzlePieces.Half_Half)
        {
            transform.GetChild(0).GetComponent<Renderer>().material = ColorMaterials[ColorIndex[0]];
            transform.GetChild(1).GetComponent<Renderer>().material = ColorMaterials[ColorIndex[1]];
        }
        else if (Pieces == PuzzlePieces.Half_Quarter_Right)
        {
            transform.GetChild(0).GetComponent<Renderer>().material = ColorMaterials[ColorIndex[0]];
            transform.GetChild(1).GetComponent<Renderer>().material = ColorMaterials[ColorIndex[1]];
            transform.GetChild(2).GetComponent<Renderer>().material = ColorMaterials[ColorIndex[2]];
        }
        else if (Pieces == PuzzlePieces.Half_Quarter_Left)
        {
            transform.GetChild(0).GetComponent<Renderer>().material = ColorMaterials[ColorIndex[0]];
            transform.GetChild(1).GetComponent<Renderer>().material = ColorMaterials[ColorIndex[1]];
            transform.GetChild(2).GetComponent<Renderer>().material = ColorMaterials[ColorIndex[2]];
        }
        else
        {
            transform.GetChild(0).GetComponent<Renderer>().material = ColorMaterials[ColorIndex[0]];
            transform.GetChild(1).GetComponent<Renderer>().material = ColorMaterials[ColorIndex[1]];
            transform.GetChild(2).GetComponent<Renderer>().material = ColorMaterials[ColorIndex[2]];
            transform.GetChild(3).GetComponent<Renderer>().material = ColorMaterials[ColorIndex[3]];
        }
    }
    
}
