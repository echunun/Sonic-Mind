using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTT : MonoBehaviour
{
    Animator ani;
    public bool exit=false;
    // Start is called before the first frame update
    void Start()
    {
        ani = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ani.SetBool("is_disappearing", true);
            ani.SetBool("is_appearing", false);
        }
    }
    public void Set_Appear()
    {
        ani.SetBool("is_disappearing", false);
        ani.SetBool("is_appearing", true);
        exit = false;
    }
    public void WhenPressedExitWindowAppear()
    {
        exit = true;
    }
}
