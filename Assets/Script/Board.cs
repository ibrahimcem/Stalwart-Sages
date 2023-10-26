using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    private GameObject tilePrefab;                              // 숫자 타일 프리팹
    [SerializeField]
    private Transform tilesParent;
    [SerializeField]
    private GameObject button;
    private List<Tile> tileList;
    private List<Tile> tiles2;
    private Vector2Int puzzleSize = new Vector2Int(3, 3);       // 4x4 퍼즐
    private float neighborTileDistance = 227;               // 인접한 타일 사이의 거리. 별도로 계산할 수도 있다.


    public Vector3 EmptyTilePosition { set; get; }          // 빈 타일의 위치
    public int Playtime { private set; get; } = 0;      // 게임 플레이 시간
    public int MoveCount { private set; get; } = 0; // 이동 횟수

    private IEnumerator Start()
    {
        tileList = new List<Tile>();
        tiles2 = new List<Tile>();

        SpawnTiles();

        UnityEngine.UI.LayoutRebuilder.ForceRebuildLayoutImmediate(tilesParent.GetComponent<RectTransform>());

        // 현재 프레임이 종료될 때까지 대기
        yield return new WaitForEndOfFrame();

        // tileList에 있는 모든 요소의 SetCorrectPosition() 메소드 호출
        tileList.ForEach(x => x.SetCorrectPosition());

        StartCoroutine("OnSuffle");
        // 게임시작과 동시에 플레이시간 초 단위 연산
        StartCoroutine("CalculatePlaytime");
    }

    private void SpawnTiles()
    {
        for (int y = 0; y < puzzleSize.y; ++y)
        {
            for (int x = 0; x < puzzleSize.x; ++x)
            {
                GameObject clone = Instantiate(tilePrefab, tilesParent);
                Tile tile = clone.GetComponent<Tile>();
                tile.Setup(this, puzzleSize.x * puzzleSize.y, y * puzzleSize.x + x + 1);
                tileList.Add(tile);
                tiles2.Add(tile);


            }
        }
    }

    private IEnumerator OnSuffle()
    {
        float current = 0;
        float percent = 0;
        float time = 1.5f;
        int count = 0;
        bool solvable = true;

        while (solvable)
        {
            while (percent < 1)
            {
                current += (Time.deltaTime) * 5;
                percent = current / time;

                int index = UnityEngine.Random.Range(0, puzzleSize.x * puzzleSize.y);
                tileList[index].transform.SetAsLastSibling();

                yield return null;

            }
            for (int i = 0; i < 9; i++)
            {
                for (int j = i + 1; j < 9; j++)
                {
                    if (tileList[i].transform.GetSiblingIndex() < tileList[j].transform.GetSiblingIndex())
                    {
                        count += 1;
                        if (Int32.Parse(tileList[i].name) > Int32.Parse(tileList[j].name))
                        {
                            count -= 1;
                        }

                    }
                }
            }
            if (count % 2 == 0 && count > 0)
            {
                solvable = false;
            }
            else
            {
                tileList.CopyTo(tiles2.ToArray());
                count = 0;
                percent = 0;
                current = 0;
            }
            yield return null;
        }

        // 원래 셔플 방식은 다른 방식이었는데 UI, GridLayoutGroup을 사용하다보니 자식의 위치를 바꾸는 것으로 설정
        // 그래서 현재 타일리스트의 마지막에 있는 요소가 무조건 빈 타일
        EmptyTilePosition = tileList[tileList.Count - 1].GetComponent<RectTransform>().localPosition;

    }

    public void IsMoveTile(Tile tile)
    {
        if (Vector3.Distance(EmptyTilePosition, tile.GetComponent<RectTransform>().localPosition) == neighborTileDistance)
        {
            Vector3 goalPosition = EmptyTilePosition;

            EmptyTilePosition = tile.GetComponent<RectTransform>().localPosition;

            MoveCount++;
            tile.OnMoveTo(goalPosition, MoveCount);

            // 타일을 이동할 때마다 이동 횟수 증가
        }
    }

    public void IsGameOver()
    {
        button.GetComponent<LibraryButton>().open();
    }
    private IEnumerator CalculatePlaytime()
    {
        while (true)
        {
            Playtime++;

            yield return new WaitForSeconds(1);
        }
    }
}
