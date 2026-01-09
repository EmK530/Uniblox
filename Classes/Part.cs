using System.Collections.Generic;
using UnityEngine;

public class Part : BasePart, ICreatable, IInstance
{
    // Called when instantiated by methods in the Luau emulator
    // Derive will be null from Instance.new
    // Derive will be a valid Part class reference if created by Clone, properties should be copied from said reference.
    // For null derives, initialize the properties using default 
    public override void OnCreate(object Derive)
    {
        base.OnCreate(Derive);
    }

    // Called when instantiated by GameLoader
    public override void OnInstantiate(Dictionary<string, object> Properties)
    {
        base.OnInstantiate(Properties);
        // Initialize properties using dictionary defined by GameLoader
        // The class should know how to properly cast each property based off the name
    }

    public override void LoadCompleted()
    {
        base.LoadCompleted();
    }

    // Main constructor, do anything universal here
    public Part()
    {

    }
}