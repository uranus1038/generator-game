using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Language : MonoBehaviour
{
	public static string getMessage(string nScriptName, int nCode)
	{
		string result = string.Empty;
		int @int = PlayerPrefs.GetInt("language", 0);
		switch(@int)
        {
			case 0: result = Language.getEnglishMessage(nScriptName, nCode); break;
			case 1: result = Language.getThaiMessage(nScriptName, nCode); break;
			default: result = Language.getEnglishMessage(nScriptName, nCode); break;
		}
		return result;
	}
	private static string getThaiMessage(string nScriptName, int nCode)
    {
		string result = string.Empty;
		switch(nScriptName)
        {
			case "LobbyGui": result = LobbyGui_th.getMessage(nCode); break; 
			case "GameGui": result = GameGui_th.getMessage(nCode); break; 
        }
		return result; 
	}
	private static string getEnglishMessage(string nScriptName, int nCode)
	{
		string result = string.Empty;
		switch (nScriptName)
		{
			case "LobbyGui": result = LobbyGui_eng.getMessage(nCode); break;
			case "GameGui": result = GameGui_eng.getMessage(nCode); break;
		}
		return result;
	}
}
