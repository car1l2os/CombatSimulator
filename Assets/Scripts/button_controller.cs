using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button_controller : MonoBehaviour {

    string previous_txt;

    GameObject[] huds;
    MenuScript ms;

    private void Start()
    {
        previous_txt = transform.GetChild(0).GetComponent<Text>().text;
        ms = GameObject.Find("CombatSimulator").GetComponent<MenuScript>();
        huds = new GameObject[5] { ms.firstMenu, ms.secondMenu, ms.thirdMenu, ms.fourthMenu, ms.fifthMenu};
    }

    public void EntraPuntero()
    {
        previous_txt = transform.GetChild(0).GetComponent<Text>().text;
        transform.GetChild(0).GetComponent<Text>().text = "Click for info";
    }

    public void SalePuntero()
    {
        transform.GetChild(0).GetComponent<Text>().text = previous_txt;
    }

    public void ShowMOB_1()
    {
        string[] info = ms.getInfoMOB(1);
        if (info != null)
        {
            setHUDs();
            GameObject tmp = huds[4];


            Transform prueba = tmp.transform.GetChild(3);
            prueba.GetComponent<Text>().text = info[0];

            GameObject texts = tmp.transform.GetChild(5).gameObject;
            for (int i = 0; i < texts.transform.childCount; i++)
            {
                texts.transform.GetChild(i).GetComponent<Text>().text = info[i + 1];
            }
        }
    }

    public void ShowMOB_2()
    {
        string[] info = ms.getInfoMOB(2);
        if (info != null)
        {
            setHUDs();
            GameObject tmp = huds[4];


            Transform prueba = tmp.transform.GetChild(3);
            prueba.GetComponent<Text>().text = info[0];

            GameObject texts = tmp.transform.GetChild(5).gameObject;
            for (int i = 0; i < texts.transform.childCount; i++)
            {
                texts.transform.GetChild(i).GetComponent<Text>().text = info[i + 1];
            }
        }
    }

    private void setHUDs()
    {
        huds[0].SetActive(false);
        huds[1].SetActive(false);
        huds[2].SetActive(false);
        huds[3].SetActive(false);
        huds[4].SetActive(true);

    }

    public void setPreviousText()
    {
        transform.GetChild(0).GetComponent<Text>().text = previous_txt;
    }

    public void setPreviousText(string value)
    {
        previous_txt = value;
    }
}
