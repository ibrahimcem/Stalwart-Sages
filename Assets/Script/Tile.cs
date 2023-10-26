using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerClickHandler
{
    private TextMeshProUGUI textNumeric;
    private Board board;
    private Vector3 correctPosition;


    private int numeric;
    public int Numeric
    {
        set
        {
            numeric = value;
            textNumeric.text = numeric.ToString();
        }
        get => numeric;
    }

    public void Setup(Board board, int hideNumeric, int numeric)
    {
        this.board = board;
        int a = 0;
        textNumeric = GetComponentInChildren<TextMeshProUGUI>();
        if (numeric == 9)
        {
            this.name = a.ToString();
        }
        else
        {
            this.name = (numeric).ToString();
        }


        Numeric = numeric;
        if (Numeric == hideNumeric)
        {
            GetComponent<UnityEngine.UI.Image>().enabled = false;
            textNumeric.enabled = false;
        }
    }

    public void SetCorrectPosition()
    {

        correctPosition = GetComponent<RectTransform>().localPosition;

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // 클릭했을 때 행동
        board.IsMoveTile(this);
    }

    public void OnMoveTo(Vector3 end, int MoveCount)
    {
        StartCoroutine(MoveTo(end, MoveCount));
    }

    private IEnumerator MoveTo(Vector3 end, int MoveCount)
    {
        float current = 0;
        float percent = 0;
        float moveTime = 0.1f;
        Vector3 start = GetComponent<RectTransform>().localPosition;
        int a = 0;
        int b = 0;
        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / moveTime;

            GetComponent<RectTransform>().localPosition = Vector3.Lerp(start, end, percent);

            yield return null;
        }
        if(correctPosition == GetComponent<RectTransform>().localPosition)
        {
            a = 1;
            transform.gameObject.GetComponent<TextMesh>().text = a.ToString();
        }
        else
        {
            a = 0;
            transform.gameObject.GetComponent<TextMesh>().text = a.ToString();
        }
        for(int i=1; i < 9; i++)
        {
            if (Int32.Parse(GameObject.Find(i.ToString()).transform.GetComponent<TextMesh>().text) == 1)
            {
                b += 1;
                if (b == 8)
                {
                    board.IsGameOver();
                }
            }
            
        }
        if (MoveCount <= 1)
        {
            for (int i = 0; i < 9; i++)
            {

                if (Int32.Parse(GameObject.Find(i.ToString()).name) - GameObject.Find(i.ToString()).transform.GetSiblingIndex() == 1)
                {
                    a = 1;
                    GameObject.Find(i.ToString()).transform.GetComponent<TextMesh>().text = a.ToString();
                }
            }
        }
        


    }

}

