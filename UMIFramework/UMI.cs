using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMI; 
namespace  UMI
{
    public class UMI : MonoBehaviour
    {

        public static void Log(string Debug)
        {
            print(Debug);
        }
        public static void Log(string[] Debug)
        {
            print(Debug);
        }
        public static void Log(int Debug)
        {
            print(Debug);
        }
        public static void Log(int Debug , string strDebug)
        {
            print(Debug+strDebug);
        }
        public static void Log(Vector3 Debug)
        {
            print(Debug);
        }
    }
}
