using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManage : MonoBehaviour
{
    public GameObject instruction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void B_OpenInstruction()
    {
        instruction.SetActive(true);
    }

    public void B_CloseInstruction()
    {
        instruction.SetActive(false);
    }

    public void B_Lv1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void B_Lv2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void B_Lv3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void B_BackMenu()
    {
        SceneManager.LoadScene("Start");
    }
}
