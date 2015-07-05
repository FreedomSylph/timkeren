﻿using UnityEngine;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveData {
	//don't change this const ever.. this const for fileName in filesystem
	private const string saveDataFileName =  "/savedData.gd";

	//it's static so we can call it from anywhere
	public static void Save() {
		BinaryFormatter bf = new BinaryFormatter();
		//Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
		FileStream file = File.Create (Application.persistentDataPath + saveDataFileName); //you can call it anything you want
		bf.Serialize(file, DataPlayer.getInstance());
		file.Close();
	}   
	
	public static DataPlayer Load() {
		if(isHaveData()) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + saveDataFileName, FileMode.Open);
			DataPlayer data = (DataPlayer)bf.Deserialize(file);
			file.Close();
			return data;
		}
		return null;
	}

	public static bool isHaveData(){
		//for check file only, if there is no file in path return false
		return File.Exists(Application.persistentDataPath +saveDataFileName);
	}
}
	