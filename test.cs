using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using UnityEngine.UI;
using TMPro;
//����ű��аѴ����notes���ֺ�����Ū����Ļ�ϵĹ��ܣ���ʵӦ�ý�Note_Names2Screen,����Ϊʲô��test����Ϊ�Ҵ���վ��ѧ�Ǹ��ļ���ȡ�����µģ�Ȼ���ֱ����������д��
public class test : MonoBehaviour
{
    public Text readText;
    private string path;
    private string path2;
    private string content;
    private string[] contents;
    public GameObject note_name;
    // Use this for initialization
    void Start()
    {
        //Debug.Log(Application.persistentDataPath);//C:/Users/uuunnn/AppData/LocalLow/DefaultCompany/sonic mind

        content = "��ǰ���¹�|���ǵ���˪|��ͷ������|��ͷ˼����|nima";
        contents = content.Split('|');
        

        string folderPath = Path.Combine(Application.persistentDataPath, "Users_Data", "note");
        string filePath = Path.Combine(folderPath, "note_names.txt");
        path2 = filePath;
        // �����ļ���·��
        Directory.CreateDirectory(folderPath);
        if (!File.Exists(filePath))
        {
            // �������ļ�
            File.Create(filePath).Close();
        }
        Notes_Name2Screen();
    }

    // Update is called once per frame
    void Update()
    {

    }
    //д������
    public void WriteTxt()
    {
        if (!File.Exists(path))
        {

            //�ı������ڴ����ı�
            FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fileStream, Encoding.UTF8);
            foreach (var item in contents)
            {
                sw.WriteLine(item);
            }
            sw.Close();
            fileStream.Close();

        }
        else
        {

        }
    }
    //��ȡ����
    public void ReadTxt()
    {
        if (File.Exists(path))
        {
            StreamReader sr = new StreamReader(path);
            readText.text = sr.ReadToEnd();
            sr.Close();
        }
    }
    //ɾ���ı�
    public void DeleTxt()
    {
        FileInfo fileInfo = new FileInfo(path);
        fileInfo.Delete();

    }
    //�����ı�
    public void CopyTxt()
    {
        if (File.Exists(path) && File.Exists(path2))
        {
            string content;
            StreamReader sr = new StreamReader(path);
            content = sr.ReadToEnd();
            StreamWriter sw = new StreamWriter(path2);
            sw.Write(content);
            sr.Close();
            sw.Close();
        }
    }
    public void Notes_Name2Screen()
    {
        //Debug.Log(path2);
        if (File.Exists(path2))
        {
            //Debug.Log("����note_names");
            float pos_y = 700;
            string[] names_and_path = File.ReadAllLines(path2);
            foreach (var NPcont in names_and_path)
            {
                string[] NPconts = NPcont.Split('|');
                //Debug.Log(conts[0] + " "+conts[1]);//�ɹ�
                //Ȼ����ȥinstantiateһ����ť��ע��λ�ã��������ȡ����ļ�
                Vector3 pos = new Vector3(50, pos_y, 0);
                GameObject NN = Instantiate(note_name, GameObject.Find("main").transform);
                NN.GetComponent<RectTransform>().SetLocalPositionAndRotation(pos, Quaternion.identity);
                NN.GetComponentInChildren<TMP_Text>().text = NPconts[0];

                pos_y -= 200;
            }
        }
    }

}

