using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScript : MonoBehaviour
{
    public string sceneToLoad;
    AsyncOperation loadingOperation;

    public Slider Slider;

    void Start()
    {
        TabletChangeOrientation();
        loadingOperation = SceneManager.LoadSceneAsync(sceneToLoad);

    }

    void Update()
    {
        float progressValue = Mathf.Clamp01(loadingOperation.progress / 0.9f);
        Slider.value = progressValue;
    }

    public static bool IsTablet()
    {
        float screenWidth = Screen.width / Screen.dpi;
        float screenHeight = Screen.height / Screen.dpi;
        float diagonalInches = Mathf.Sqrt(Mathf.Pow(screenWidth, 2) + Mathf.Pow(screenHeight, 2));
        var aspectRatio = Mathf.Max(Screen.width, Screen.height) / Mathf.Min(Screen.width, Screen.height);
        if ((diagonalInches > 6.5f && aspectRatio < 2f))
            return true;
        else
            return false;
    }

    private void TabletChangeOrientation()
    {
        if (Application.platform == RuntimePlatform.Android && IsTablet())
        {
            Screen.orientation = ScreenOrientation.LandscapeLeft;
            // Tablets
        }
    }


}
