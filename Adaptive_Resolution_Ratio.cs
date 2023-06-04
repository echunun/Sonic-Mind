using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Adaptive_Resolution_Ratio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int h = Screen.height;
        int w = Screen.width;
        Debug.Log(h.ToString()+" "+w.ToString());
        //Screen.SetResolution(w, h, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
