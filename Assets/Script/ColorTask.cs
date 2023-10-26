using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColorTask : MonoBehaviour, IDragHandler, IEndDragHandler
{
    Vector2 startPosition;
    Vector2 start2Position;
    public GameObject buttons;
    public GameObject empty;
    public GameObject mixButton;
    public GameObject colorTab;
    List<string> list;
    List<string> list2;
    public Hashtable colors;
    Colors colors2 = new Colors();
    Color emptyColor;
    Image startImage;
    bool update;
    public GameObject number;
    int x;
    int y;
    private void Start()
    {
        startPosition = transform.position;

        colors = colors2.ColorsHash;
        update = true;
        x = Random.Range(0, 9);
        y = (int)empty.transform.position.x;
        Debug.Log(y);

    }
    private void FixedUpdate()
    {
        if (update == true)
        {
            emptyColor = transform.GetComponent<Image>().color;
            startImage = transform.GetComponent<Image>();
            update = false;
        }
        
    }
    public void OnDrag(PointerEventData eventData)
    {
        startImage.color = emptyColor;
        start2Position = startPosition;
        Vector2 position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 0.5f);
        foreach(Collider2D collider in colliders)
        {
            if(collider.transform.name == "empty")
            {
                UpdatePosition(collider.transform.position);
                start2Position = collider.transform.position;
                return;
            }
        }
        UpdatePosition(position);
    }
    private void UpdatePosition(Vector2 newPosition)
    {
        transform.position = newPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        UpdatePosition(start2Position);
        Debug.Log("tamam");
        int a = 0;
        
        list = new List<string>();
        list.Clear();
        list2 = new List<string>();
        list2.Clear();
        for(int i = 0; i < 5; i++)
        {
            list2.Add(buttons.transform.GetChild(i).gameObject.name);
        }
        foreach(string name in list2)
        {
            int z = (int)GameObject.Find("/ColorTask/Panel/colors/" + name).transform.position.x;
            Debug.Log(GameObject.Find("/ColorTask/Panel/colors/" + name).transform.position+ "==" +empty.transform.position);
            if(z == y)
            {
                Debug.Log("tamam2");
                list.Add(name);
                a += 1;
                
            }
        }
        if (a >= 3)
        {
            Debug.Log("tamam3");
            Color mix = new Color(0, 0, 0, 0);
            for (int j = 0; j < list.Count; j++)
            {
                ColorUtility.TryParseHtmlString((string)colors[list[j]], out Color color);
                mix += color;
            }
            mix /= list.Count;
            mix.a = 1;
            for (int b = 0; b < 5; b++)
            {
                if (buttons.transform.GetChild(b).gameObject.transform.position == empty.transform.position)
                {
                    Debug.Log("deneme"+mix);
                    Image image = buttons.transform.GetChild(b).gameObject.GetComponent<Image>();
                    image.color = mix;
                }

            }
            if (mixButton.GetComponent<Image>().color == mix)
            {
                StartCoroutine(ExampleCoroutine());
                Debug.Log(mixButton.GetComponent<Image>().color + "olduu");
            }
        }
    }
    IEnumerator ExampleCoroutine()
    {
        number.GetComponent<Text>().text = x.ToString();
        number.SetActive(true);
        yield return new WaitForSeconds(1);
        colorTab.GetComponent<ColorTaskButton>().canvas.SetActive(false);
        number.SetActive(false);
        colorTab.GetComponent<ColorTaskButton>().comleted = true;
    }
}
