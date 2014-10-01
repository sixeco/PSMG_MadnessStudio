using UnityEngine;
using System.Collections;

public class WeaponSelection : MonoBehaviour {

    public Texture[] GunImages;
    private Rect GunsRectLeft;
    private int GunSelectionIndexLeft;
    private Rect GunsRectRight;
    private int GunSelectionIndexRight;

    private Font selectionFont;

    private Rect leftBox;
    private Rect rightBox;

    void Awake()
    {
        GunSelectionIndexLeft = 0;
        GunSelectionIndexRight = 0;
        selectionFont = this.GetComponent<MainMenuView>().generalFont;
        GunImages = GameObject.Find("Data").GetComponent<TextureData>().GunImages;
        GunsRectLeft = new Rect(Screen.width / 25, Screen.height / 6, Screen.width / 7, Screen.height / 2);
        leftBox = new Rect(Screen.width / 25 - Screen.width / 50, Screen.height / 8, Screen.width / 6, Screen.height / 2);
        GunsRectRight = new Rect(Screen.width - (Screen.width / 7 + Screen.width / 25), Screen.height / 6, Screen.width / 7, Screen.height / 2);
        rightBox = new Rect(Screen.width - Screen.width / 6 - Screen.width / 25, Screen.height / 8, Screen.width / 6, Screen.height / 2);
    }

    void Update()
    {
        switch (GunSelectionIndexLeft)
        {
            case 0:
                GameObject.Find("Data").GetComponent<WeaponsData>().Left = WeaponsData.SelectedWeapon.Rabbit_TwinCannon;
                break;
            case 1:
                GameObject.Find("Data").GetComponent<WeaponsData>().Left = WeaponsData.SelectedWeapon.Tiger_RocketLauncher;
                break;
            case 2:
                GameObject.Find("Data").GetComponent<WeaponsData>().Left = WeaponsData.SelectedWeapon.Cobra_Railgun;
                break;
            case 3:
                GameObject.Find("Data").GetComponent<WeaponsData>().Left = WeaponsData.SelectedWeapon.Woodpecker_Gatling;
                break;
            default:
                GameObject.Find("Data").GetComponent<WeaponsData>().Left = WeaponsData.SelectedWeapon.Rabbit_TwinCannon;
                break;
        }
        switch (GunSelectionIndexRight)
        {
            case 0:
                GameObject.Find("Data").GetComponent<WeaponsData>().Right = WeaponsData.SelectedWeapon.Rabbit_TwinCannon;
                break;
            case 1:
                GameObject.Find("Data").GetComponent<WeaponsData>().Right = WeaponsData.SelectedWeapon.Tiger_RocketLauncher;
                break;
            case 2:
                GameObject.Find("Data").GetComponent<WeaponsData>().Right = WeaponsData.SelectedWeapon.Cobra_Railgun;
                break;
            case 3:
                GameObject.Find("Data").GetComponent<WeaponsData>().Right = WeaponsData.SelectedWeapon.Woodpecker_Gatling;
                break;
            default:
                GameObject.Find("Data").GetComponent<WeaponsData>().Right = WeaponsData.SelectedWeapon.Rabbit_TwinCannon;
                break;
        }
    }

    void OnGUI()
    {
        GUI.skin.box.font = selectionFont;
        GUI.skin.button.font = selectionFont;

        GUI.Box(leftBox, "Select left weapon");
        GUI.Box(rightBox, "Select right weapon");
        GunSelectionIndexLeft = GUI.SelectionGrid(GunsRectLeft, GunSelectionIndexLeft, GunImages, 1);
        GunSelectionIndexRight = GUI.SelectionGrid(GunsRectRight, GunSelectionIndexRight, GunImages, 1);
        
    }
}
