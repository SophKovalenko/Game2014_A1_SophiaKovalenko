///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//  Mobile Game Development
//  Game 2014 Assignment 1
//  Run Princess, Run! By Sophia Kovalenko - 101333565
//  This program contains the scripts for a simple mobile game still in development.
//
//  Created: October 22nd, 2022
//  Last modified: October 22nd, 2022
//  - this script store the static time variable between scenes and a static bool to unlock level 2 scene in scene navigator
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeKeeper : MonoBehaviour
{
    public static float totalTime;
    public static bool isCurrentLevel2 = false;
}
