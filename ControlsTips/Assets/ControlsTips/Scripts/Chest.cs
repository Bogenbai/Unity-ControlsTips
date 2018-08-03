using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    public GameObject chestOpen;
    public GameObject chestClose;
    bool canInteract;
    bool isChestOpen;


    void Update()
    {
        ControlsTipsController();

        if (canInteract)
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!isChestOpen)
                {
                    chestOpen.SetActive(true);
                    chestClose.SetActive(false);
                    isChestOpen = true;
                }
                else
                {
                    chestOpen.SetActive(false);
                    chestClose.SetActive(true);
                    isChestOpen = false;
                }
            }
    }

    void ControlsTipsController()
    {
        if (canInteract)
        {
            if (!isChestOpen)
            {
                ControlsTips.Instance.ShowTip("OpenChest");
                ControlsTips.Instance.HideTip("CloseChest");
            }
            else
            {
                ControlsTips.Instance.HideTip("OpenChest");
                ControlsTips.Instance.ShowTip("CloseChest");
            }
        }
        else
        {
            ControlsTips.Instance.HideTip("OpenChest");
            ControlsTips.Instance.HideTip("CloseChest");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            canInteract = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            canInteract = false;
    }
}
