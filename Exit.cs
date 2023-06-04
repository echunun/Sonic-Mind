using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public GameObject exit;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&GameObject.Find("tutorial").GetComponent<MainTT>().exit)
        {
            exit.SetActive(true);
        }
    }
    public void Yes()
    {
        Application.Quit();
    }
    public void No()
    {
        GameObject.Find("exit").GetComponent<Animator>().SetBool("is_disappearing", true);
    }

}
