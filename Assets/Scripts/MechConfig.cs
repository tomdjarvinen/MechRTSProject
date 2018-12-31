using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MechConfig
{
    ArmorModule[] mechArmorModules;
    FrameConfig mechFrame;
    WeaponConfig [] mechWeapons;
    PowerAllocator [] mechPowerModes;

}

public struct ArmorModule
{
    string visualAssetName;
    string attachmentPointName;
    
}

public struct FrameConfig
{

}
public struct WeaponConfig
{

}
public struct PowerAllocator
{

}