using System;

namespace UnityHelper
{
    [Serializable]
    public enum EventID
    {
        None = 0,
        ChangeMode, 
        RotateMode,
        ZoomMode,
        DefaultMode,
        Shooting,
        PlaySmokeEffect,
        Reload,
        GoToObjectMenu,
        GoToTypeObjectMenu,
        GoToMenuScene,
        GoToGamePlayScene,
        ChangeObjectSimulation,
        ChangeTank,
        ChangeJuice,
        ChangeBackground,
    }
    
    //
    
    [Serializable]
    public enum PrimitiveDataType
    {
        Int,
        Float,
        String,
        Bool,
        None
    }
}