using UnityEngine;

public class OptionsMenuController : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject optionsMenu;
    //TODO CONFUIGURAR EL VOLUME MUSIC...
    public void OpenOptions()
    {
        optionsPanel.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void CloseOptions()
    {

        optionsPanel.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

}
