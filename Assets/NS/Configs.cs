using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Configs
{

    //configs
    public static int b_play = 1;
    public static int b_play2 = 0;
    public static int b_home = 0;
    public static int b_back = 1;
    public static int b_fight = 1;
    public static int b_win = 1;
    public static int b_retry = 1;
    public static int b_next = 1;
    public static int b_lose = 1;
    public static int b_addtime = 1;
    public static int timeAds = 1;
    public static int is_banner = 1;
    public static float startTime = -60;
    public static bool is_run = false;
    public static int is_toilet = 0;
    public static bool CheckTimeShowAds()
    {
        float currentTime = Time.realtimeSinceStartup;
        if (currentTime - startTime > timeAds)
            return true;

        return false;
    }
    public static void SetStartTime()
    {
        startTime = Time.realtimeSinceStartup;
    }
}
