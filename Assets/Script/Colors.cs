using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colors
{
    private Hashtable colors = new Hashtable
    {
        {"Black","#000000"},
        {"White","#FFFFFF"},
        {"Red","#FF0000"},
        {"Lime","#00FF00"},
        {"Blue","#0000FF"},
        {"Yellow","#FFFF00"},
        {"Aqua","#00FFFF"},
        {"Fuchsia","#FF00FF"},
        {"Silver","#C0C0C0"},
        {"Gray","#808080"},
        {"Maroon","#800000"},
        {"Olive","#808000"},
        {"Green","#008000"},
        {"Purple","#800080"},
        {"Teal","#008080"},
        {"Navy","#000080"}

    };
    private List<string> colorName = new List<string>
    {
        "Black",
        "White",
        "Red",
        "Lime",
        "Blue",
        "Yellow",
        "Aqua",
        "Fuchsia",
        "Silver",
        "Gray",
        "Maroon",
        "Olive",
        "Green",
        "Purple",
        "Teal",
        "Navy",
    };
    private Color mix;
    private List<string> buttonColor;

    public List<string> ColorName { get => colorName; }
    public Hashtable ColorsHash { get => colors;}
    public List<string> ButtonColor { get => buttonColor; set => buttonColor = value; }
    public Color Mix { get => mix; set => mix = value; }
}
