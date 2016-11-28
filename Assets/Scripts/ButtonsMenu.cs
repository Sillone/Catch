using UnityEngine;
using System.Collections;

public class ButtonsMenu: MonoBehaviour
{
    public GameObject Store;

    void OnMouseUpAsButton()
    {
        print("ya pasha ebashu");
        switch (gameObject.name)
        {
            case "Keg":
                Application.LoadLevel("one");
                break;
            case "Clock":
                Application.LoadLevel("two");
                break;
            case "Lamp":
                Application.LoadLevel("three");
                break;
            case "Barman":
                Store.SetActive(true);
                break;
            case "CloseStore":
                {
                    print("ya pasha ebashu");
                    Store.SetActive(false);
                    break;
                }
        }

    }
}