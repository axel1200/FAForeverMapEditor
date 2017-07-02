﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PropData : MonoBehaviour {

	public		int ID;
	public		Text		NameField;
	public		Text		PathField;
	public		Text		MassField;
	public		Text		EnergyField;
	public		Text		Count;
	public		Text		TotalMassField;
	public		Text		TotalEnergyField;

	public void SetPropList(int _ID, string name, float mass, float energy, int count, string path){
		ID = _ID;
		NameField.text = name;
		MassField.text = (mass).ToString();
		EnergyField.text = (energy).ToString();

		PathField.text = path;

		Count.text = "x" + count;
		TotalMassField.text = (mass * count).ToString();
		TotalEnergyField.text = (energy * count).ToString();
	}

	public void SetPropPaint(int _ID, string name)
	{
		ID = _ID;
		NameField.text = name;
	}

	public void RemoveProp()
	{
		PropsReader.Current.RemoveProp(ID);
	}

	public void OverPropEnter()
	{
		PropsReader.Current.ShowPreview(ID, gameObject);
	}

	public void OverPropExit()
	{
		PropsReader.Current.Preview.Hide(gameObject);
	}
}
