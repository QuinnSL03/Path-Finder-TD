using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPicker : MonoBehaviour
{
    // Start is called before the first frame update

    public void SelectLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
