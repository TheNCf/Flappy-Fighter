using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndScreen : Window
{
    public event Action RestartButtonClicked;

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
        RestartButtonClicked?.Invoke();
    }
}
