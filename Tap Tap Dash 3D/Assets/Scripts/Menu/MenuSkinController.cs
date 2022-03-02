using System;

public static class MenuSkinController
{
    public static event Action ChooseSkinEvent;

    public static string CurrentSkinName = "Villager";

    public static void ChangeSkin(string skinName)
    {
        CurrentSkinName = skinName;
        ChooseSkinEvent();
    }
}
