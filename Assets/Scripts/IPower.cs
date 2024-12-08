using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPower
{
    string Name { get; }
    string Description { get; }

    char Cooldown { get; }

    void Activate();

    void Deactivate();

    void UpdateCooldown();
}