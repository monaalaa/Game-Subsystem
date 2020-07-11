using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverController : MonoBehaviour
{
    private static readonly ObserverController _instance = new ObserverController();
   
    public static ObserverController Get()
    {
        return _instance;
    }

    public Observable<int> observableInt = new Observable<int>();

    public Observable<List<int>> observableProperity = new Observable<List<int>>();
}
