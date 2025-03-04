using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    int[,] PieceMatrix=new int[5,5];
    UI_Manager UIManager;
    TouchControls TC;
    [SerializeField] GameObject[] Pieces;
    [SerializeField] string[] LevelData;
    GameObject[] LevelPieces;
    Vector3 MarshalPoint=new Vector3(20,20,20);
    Vector3 StartPoint = new Vector3(2, 2, -1);
    int PieceIndex = 0;
    int Moves = 0;
    [SerializeField]  int Target;
    void Start()
    {
        UIManager=GetComponent<UI_Manager>();
        TC = GetComponent<TouchControls>();
        RefreshLevelMatrix();
        LoadLevelData();
    }

    public void LoadFirstPiece()
    {
        LevelPieces[PieceIndex].SetActive(true);
        LevelPieces[PieceIndex].transform.position = StartPoint;
        TC.objectToMove = LevelPieces[PieceIndex].transform;
        UIManager.ShowNextPiece(LevelData[PieceIndex + 1]);
        UIManager.RefreshUI(Moves, Target);
    }
    void LoadNextPiece()
    {
        PieceIndex++;
        Moves++;
        if (PieceIndex == LevelData.Length - 1)
        {
            UIManager.ShowLastPiece();
        }
        else
        {
            UIManager.ShowNextPiece(LevelData[PieceIndex + 1]);
        }
        
        if (PieceIndex == LevelData.Length - 1)
        {
            LevelFailed();
        }
        else 
        {
            LevelPieces[PieceIndex].SetActive(true);
            LevelPieces[PieceIndex].transform.position = StartPoint;
            TC.objectToMove = LevelPieces[PieceIndex].transform;
        }
        UIManager.RefreshUI(Moves, Target);
    }
    void LoadLevelData() //to do : Read from text asset
    {
        LevelPieces=new GameObject[LevelData.Length];
        for (int i = 0; i < LevelData.Length; i++) 
        {
            
            string[] str= LevelData[i].Split(',');
            GameObject temp = null;
            if (str[0] == "0")
            {
                temp=Instantiate(Pieces[0], MarshalPoint, Quaternion.identity);
                temp.GetComponent<PieceIDManager>().ColorIndex[0] = int.Parse(str[1]);
            }
            else if (str[0] == "1")
            {
                temp = Instantiate(Pieces[1], MarshalPoint, Quaternion.identity);
                temp.GetComponent<PieceIDManager>().ColorIndex[0] = int.Parse(str[1]);
                temp.GetComponent<PieceIDManager>().ColorIndex[1] = int.Parse(str[2]);
            }
            else if (str[0] == "2")
            {
                temp = Instantiate(Pieces[2], MarshalPoint, Quaternion.identity);
                temp.GetComponent<PieceIDManager>().ColorIndex[0] = int.Parse(str[1]);
                temp.GetComponent<PieceIDManager>().ColorIndex[1] = int.Parse(str[2]);
                temp.GetComponent<PieceIDManager>().ColorIndex[2] = int.Parse(str[3]);
            }
            else if (str[0] == "3")
            {
                temp = Instantiate(Pieces[3], MarshalPoint, Quaternion.identity);
                temp.GetComponent<PieceIDManager>().ColorIndex[0] = int.Parse(str[1]);
                temp.GetComponent<PieceIDManager>().ColorIndex[1] = int.Parse(str[2]);
                temp.GetComponent<PieceIDManager>().ColorIndex[2] = int.Parse(str[3]);
            }
            else if (str[0] == "4")
            {
                temp = Instantiate(Pieces[4], MarshalPoint, Quaternion.identity);
                temp.GetComponent<PieceIDManager>().ColorIndex[0] = int.Parse(str[1]);
                temp.GetComponent<PieceIDManager>().ColorIndex[1] = int.Parse(str[2]);
                temp.GetComponent<PieceIDManager>().ColorIndex[2] = int.Parse(str[3]);
                temp.GetComponent<PieceIDManager>().ColorIndex[3] = int.Parse(str[4]);
            }
            temp.SetActive(false);
            temp.transform.name = "P_" + i.ToString() + "_" + temp.transform.name;
            LevelPieces[i] =temp;
        }
    }
    void RefreshLevelMatrix()
    {
        for (int i = 0; i < 5; i++)
        {
            for (int k = 0; k < 5; k++)
            {
                PieceMatrix[i, k] = 0;
            }
        }
    }

    void Update()
    {
        
    }

    
    public void SendPieceToPosition(Transform obj)
    {
        int column = Mathf.RoundToInt(obj.transform.position.x);
        int cell = 0;
        Vector2 PositionToFit = Vector2.zero;
        for (int i = 4; i >= 0; i--)
        {
            if (PieceMatrix[column, i] == 0)
            {
                cell = i;
                break;
            }
        }
        if (PieceMatrix[column, cell] == 1) //no more room!
        {
            LevelFailed();
        }
        else
        {
            PositionToFit = new Vector2(column, cell);
            PieceMatrix[column, cell] = 1;
            obj.DOMoveY(-cell, 0.5f);
            Invoke("LoadNextPiece", 1);
            CheckExplosion(column, cell);
        }

    }
    void CheckExplosion(int X,int Y)
    {
        if (X + 1 <= 4)//check right
        {
            if (PieceMatrix[X + 1, Y]==1)
            { 
                
            }
        }
        if (X - 1 >= 0)//check left
        { 
            
        }
    }

    void LevelFailed()
    {
        StopGamePlay();
        UIManager.ShowLevelFailed();
    }
    void LevelSuccess()
    {
        UIManager.ShowLevelSuccess();
    }
    void StopGamePlay()
    {
        TC.GamePaused =true;
    }
}
