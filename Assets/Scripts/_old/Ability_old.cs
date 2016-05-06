﻿using UnityEngine;
using System.Collections.Generic;
using System;

/// <summary>
/// Abstract base class for all abilities.
/// Sets up the basic functions required for an ability to operate.
/// </summary>
public abstract class Ability {

    /// <summary>
    /// Called when an ability is used. The string represents 
    /// </summary>
    private Action<string> onAbilityUsed;

    public string AbilityName { get; protected set; }

    // will probably change this to a 'sprite Repository/cache' later on. So all sprites are loaded from one place
    public Sprite AbilityIcon { get; protected set; }

    /// <summary>
    /// This is the function to override for the functionality of the ability (This is where all the logic goes)
    /// Will probably be renamed
    /// </summary>
    protected abstract void AbilityImplementation();

    public void UseAbility()
    {
        AbilityImplementation();

        if (onAbilityUsed == null)
            return;

        onAbilityUsed(AbilityName);
    }
}