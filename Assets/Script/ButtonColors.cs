using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColors : MonoBehaviour
{
    Colors colors = new Colors();
    public Hashtable buttonColor;
    List<string> colorName;
    List<string> buttonColors;
    Color mix;
    public GameObject gameObject1;
    // Start is called before the first frame update
    void Start()
    {
        buttonColor = colors.ColorsHash;
        colorName = colors.ColorName;
        buttonColors = new List<string>();
        for (int i = 0; i < 5; i++)
        {
            int x = Random.Range(0, colorName.Count - 1);
            Image image = transform.GetChild(i).gameObject.GetComponent<Image>();
            GameObject gameObject = transform.GetChild(i).gameObject;
            gameObject.name = colorName[x];
            buttonColors.Add(colorName[x]);
            Color color;
            ColorUtility.TryParseHtmlString((string)buttonColor[colorName[x]], out color);
            image.color = color;
            colorName.RemoveAt(x);
        }
        for (int j = 0; j < 3; j++)
        {
            int y = Random.Range(0, buttonColors.Count - 1);
            Color color2;
            ColorUtility.TryParseHtmlString((string)buttonColor[buttonColors[y]], out color2);
            Debug.Log(buttonColors[y]);
            buttonColors.RemoveAt(y);
            mix += color2;
        }
        mix /= 3;
        mix.a = 1;
        Image image2;
        image2 = gameObject1.GetComponent<Image>();
        image2.color = mix;
    }

}
