using System;
using UnityEngine;

public class PotionCountChangedEventArgs : EventArgs {
    public int CurrentPotions { get; }

    public PotionCountChangedEventArgs(int ñurrentPotions) { CurrentPotions = ñurrentPotions; }
}
