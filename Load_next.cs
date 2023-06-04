using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_next : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name!="main")
            {
                if(SceneManager.GetActiveScene().name!="note"&& SceneManager.GetActiveScene().name != "point")
                gameObject.GetComponent<Animator>().SetBool("is_back", true);
                else if (GameObject.Find("File_Reader").GetComponent<Animator>().GetBool("is_disappearing"))
                {
                    gameObject.GetComponent<Animator>().SetBool("is_back", true);
                }
            }
        }
    }
    public void Load_next_scene()
    {
        gameObject.GetComponent<Animator>().SetBool("is_entering", true);
    }
    public void Set_dissipate_true()
    {
        gameObject.GetComponent<Animator>().SetBool("is_dissipating", true);
    }
    public void SceneManager_load_search()
    {
        SceneManager.LoadScene("search");
    }
    public void SceneManager_load_note()
    {
        SceneManager.LoadScene("note");
    }
    public void SceneManager_load_point()
    {
        SceneManager.LoadScene("point");
    }
    public void Back_to_main()
    {
        SceneManager.LoadScene("main");
    }
}
