using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.Mathematics;

public class UI_Manager : MonoBehaviour
{
    GamePlayManager GMP;
    [SerializeField] TextMeshProUGUI txtMovesCount;
    [SerializeField] TextMeshProUGUI txtTargetCount;
    [SerializeField] Image imgNextPiece;
    [SerializeField] Sprite[] Pieces;

    [SerializeField] GameObject PnlStart;
    [SerializeField] GameObject PnlLevelFailed;
    [SerializeField] GameObject PnlLevelSuccess;
    
    void Start()
    {
        GMP= gameObject.GetComponent<GamePlayManager>();
        PnlStart.gameObject.SetActive(true);
    }

    void Update()
    {
        
    }

    public void StartPlaying()
    {
        GMP.Invoke("LoadFirstPiece", 2);
    }

    public void ShowLevelFailed()
    { 
        PnlLevelFailed.SetActive(true);
    }

    public void ShowLevelSuccess()
    { 
        PnlLevelSuccess.SetActive(true);
    }

    public void RefreshUI(int moves,int target)
    {
        txtMovesCount.text = moves.ToString();
        txtTargetCount.text = target.ToString();
    }

    public void ShowNextPiece(string data)
    {
        string[] str = data.Split(',');
        GameObject temp = null;
        for (int i = 0; i < imgNextPiece.transform.childCount-1; i++) 
        {
            imgNextPiece.transform.GetChild(i).gameObject.SetActive(false);
        }
        if (str[0] == "0") //single
        {
            
            imgNextPiece.transform.GetChild(0).gameObject.SetActive(true);
            imgNextPiece.transform.GetChild(0).GetComponent<Image>().sprite = Pieces[int.Parse(str[1])];
        }
        else if (str[0] == "1")//half half
        {
            Transform prew = imgNextPiece.transform.GetChild(1);
            prew.gameObject.SetActive(true);
            prew.GetChild(0).GetComponent<Image>().sprite = Pieces[int.Parse(str[1])];
            prew.GetChild(1).GetComponent<Image>().sprite = Pieces[int.Parse(str[2])];
            
        }
        else if (str[0] == "2")//Half Quarter Right
        {
            Transform prew = imgNextPiece.transform.GetChild(2);
            prew.gameObject.SetActive(true);
            prew.GetChild(0).GetComponent<Image>().sprite = Pieces[int.Parse(str[1])];
            prew.GetChild(1).GetComponent<Image>().sprite = Pieces[int.Parse(str[2])];
            prew.GetChild(2).GetComponent<Image>().sprite = Pieces[int.Parse(str[3])];
        }
        else if (str[0] == "3")// Half Quarter left
        {
            Transform prew = imgNextPiece.transform.GetChild(2);
            prew.gameObject.SetActive(true);
            prew.GetChild(0).GetComponent<Image>().sprite = Pieces[int.Parse(str[1])];
            prew.GetChild(1).GetComponent<Image>().sprite = Pieces[int.Parse(str[2])];
            prew.GetChild(2).GetComponent<Image>().sprite = Pieces[int.Parse(str[3])];
        }
        else if (str[0] == "4")//All quarter
        {
            Transform prew = imgNextPiece.transform.GetChild(2);
            prew.gameObject.SetActive(true);
            prew.GetChild(0).GetComponent<Image>().sprite = Pieces[int.Parse(str[1])];
            prew.GetChild(1).GetComponent<Image>().sprite = Pieces[int.Parse(str[2])];
            prew.GetChild(2).GetComponent<Image>().sprite = Pieces[int.Parse(str[3])];
            prew.GetChild(3).GetComponent<Image>().sprite = Pieces[int.Parse(str[4])];
        }
    }
    public void ShowLastPiece()
    {
        for (int i = 0; i < imgNextPiece.transform.childCount - 1; i++)
        {
            imgNextPiece.transform.GetChild(i).gameObject.SetActive(false);
        }
        imgNextPiece.GetComponent<Image>().enabled = true;
    }
}
