using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartScreen : Window
{
    public event Action PlayButtonClicked;

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        ActionButton.interactable = true;
    }

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        ActionButton.interactable = false;
    }

    protected override void OnButtonClick()
    {
        PlayButtonClicked?.Invoke();
    }
}
