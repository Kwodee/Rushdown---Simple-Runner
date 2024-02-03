using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProCoderScript : MonoBehaviour
{
    private GameObject[] characterList;

    private int index;

    private void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");

        characterList = new GameObject[transform.childCount];

        // Fill aray with models
        for (int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }

        //render off
        foreach (GameObject go in characterList)
            go.SetActive(false);

        // first index toggle
        if (characterList[index])
            characterList[index].SetActive(true);       
    }

    public void toggleLeft()
    {
        // off old
        characterList[index].SetActive(false);

        index--; //index -=1; index = index - 1;
        if (index < 0)
            index = characterList.Length - 1;

        //on new
        characterList[index].SetActive(true);
    }
    public void toggleRight()
    {
        // off old
        characterList[index].SetActive(false);

        index++; //index -=1; index = index - 1;
        if (index == characterList.Length)
            index = 0;
          

        //on new
        characterList[index].SetActive(true);
    }
    public void select()
    {
        PlayerPrefs.SetInt("CharacterSelected", index);
        SceneManager.LoadScene("Menu");
    }
}
