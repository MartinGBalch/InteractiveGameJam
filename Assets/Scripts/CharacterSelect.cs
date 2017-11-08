using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterSelect : MonoBehaviour
{
    public Image target;

    public Sprite[] select;
    public int currentIndex
    {
        private set; get;
    }

    public void NextPress()
    {
        currentIndex = ((currentIndex + 1) % select.Length);
        RefreshTarget();
    }

    public void PrevPress()
    {
        currentIndex = ((currentIndex - 1) % select.Length);
        RefreshTarget();
    }

    public void RefreshTarget()
    {
        target.sprite = select[currentIndex];
    }
}
