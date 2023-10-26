using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class KeyPad1 : MonoBehaviour
{
    public GameObject keypad1UI;
    public GameObject door;
    public Text passwordText;
    public string password;
    public GameObject task1;
    public GameObject task2;
    public GameObject task3;
    public GameObject canvas;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    private void Start()
    {
        
    }
    public void KeyButton(string key)
    {
        if (passwordText.text.Length < 4)
        {
            passwordText.text += key;
        }


    }
    public void ResetPassword()
    {
        passwordText.text = "";
    }
    public void CheckPassword()
    {

        if (passwordText.text == password)
        {
            door.transform.GetComponent<Finish>().completed = true;
            keypad1UI.SetActive(false);
            ResetPassword();

        }
        else
        {
            ResetPassword();
        }
    }
    private void OnMouseDown()
    {
        if (!door.transform.GetComponent<Finish>().completed && task1.transform.GetComponent<LibraryButton>().isOpen && task2.transform.GetComponent<ElectricBox>().completed
            &&task3.transform.GetComponent<ColorTaskButton>().comleted)
        {
            password = text1.transform.GetComponent<Text>().text;
            password += text2.transform.GetComponent<Text>().text;
            password += text3.transform.GetComponent<Text>().text;
            keypad1UI.SetActive(true);
            ResetPassword();
        }
        else
        {
            StartCoroutine(ExampleCoroutine());
        }
        

    }
    public void Close()
    {
        keypad1UI.SetActive(false);
        ResetPassword();
    }
    IEnumerator ExampleCoroutine()
    {
        canvas.SetActive(true);
        yield return new WaitForSeconds(3);
        canvas.SetActive(false);

    }
}
