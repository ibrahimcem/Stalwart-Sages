using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    private GameObject tilePrefab;                              // ���� Ÿ�� ������
    [SerializeField]
    private Transform tilesParent;
    [SerializeField]
    private GameObject button;
    private List<Tile> tileList;
    private List<Tile> tiles2;
    private Vector2Int puzzleSize = new Vector2Int(3, 3);       // 4x4 ����
    private float neighborTileDistance = 227;               // ������ Ÿ�� ������ �Ÿ�. ������ ����� ���� �ִ�.


    public Vector3 EmptyTilePosition { set; get; }          // �� Ÿ���� ��ġ
    public int Playtime { private set; get; } = 0;      // ���� �÷��� �ð�
    public int MoveCount { private set; get; } = 0; // �̵� Ƚ��

    private IEnumerator Start()
    {
        tileList = new List<Tile>();
        tiles2 = new List<Tile>();

        SpawnTiles();

        UnityEngine.UI.LayoutRebuilder.ForceRebuildLayoutImmediate(tilesParent.GetComponent<RectTransform>());

        // ���� �������� ����� ������ ���
        yield return new WaitForEndOfFrame();

        // tileList�� �ִ� ��� ����� SetCorrectPosition() �޼ҵ� ȣ��
        tileList.ForEach(x => x.SetCorrectPosition());

        StartCoroutine("OnSuffle");
        // ���ӽ��۰� ���ÿ� �÷��̽ð� �� ���� ����
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

        // ���� ���� ����� �ٸ� ����̾��µ� UI, GridLayoutGroup�� ����ϴٺ��� �ڽ��� ��ġ�� �ٲٴ� ������ ����
        // �׷��� ���� Ÿ�ϸ���Ʈ�� �������� �ִ� ��Ұ� ������ �� Ÿ��
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

            // Ÿ���� �̵��� ������ �̵� Ƚ�� ����
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