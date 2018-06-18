﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Ozone.UI;

public class UnitListObject : MonoBehaviour {

	public Text GroupName;
	public Color NameRoot;
	public Color NameGroup;

	public Text UnitsCount;
	public Transform Pivot;
	public VerticalLayoutGroup Layout;
	public int InstanceId;

	public Image Selection;
	public Color ColorNormal;
	public Color ColorSelected;
	public Color ColorSelectedFirst;

	public GameObject Header;
	public GameObject SelectButton;
	public GameObject RemoveButton;

	public Transform ExpandBtn;

	public MapLua.SaveLua.Army Owner;
	public MapLua.SaveLua.Army.UnitsGroup Source;
	public MapLua.SaveLua.Army.UnitsGroup Parent;
	public System.Action<UnitListObject> AddAction;
	public System.Action<UnitListObject> RemoveAction;
	public System.Action<UnitListObject> SelectAction;
	public System.Action<UnitListObject> RenameAction;
	public System.Action<UnitListObject> ExpandAction;

	public void SetTab(int count)
	{
		if (count > 5)
			count = 5;

		Layout.padding.left = 2 + count * 6;
	}


	public bool IsRoot = false;
	bool _expand;
	public bool IsExpanded
	{
		get
		{
			return _expand;
		}
		set
		{
			_expand = value;

			ExpandBtn.localRotation = Quaternion.Euler(Vector3.back * (_expand ? (90) : (0)));
			Pivot.gameObject.SetActive(_expand);

		}
	}
	public void SetGroup(MapLua.SaveLua.Army Owner, MapLua.SaveLua.Army.UnitsGroup Data, MapLua.SaveLua.Army.UnitsGroup Parent, bool root)
	{
		this.Owner = Owner;
		this.Source = Data;
		this.Parent = Parent;
		IsRoot = root;

		IsExpanded = Data.Expanded;

		if (IsRoot)
		{
			GroupName.text = Owner.Name;
			//NameInputField.SetValue(Owner.Name);
			RemoveButton.SetActive(false);
			//UnitsCount.gameObject.SetActive(false);
		}
		else
		{
			GroupName.text = Data.Name;
			//NameInputField.SetValue(Data.Name);
			RemoveButton.SetActive(true);
			//UnitsCount.gameObject.SetActive(true);
		}
		UpdateValues(Data.Units.Count, Data.UnitGroups.Count);


		RenameEnd();
		Selection.color = ColorNormal;
		GroupName.color = IsRoot ? NameRoot : NameGroup;
	}



	public void UpdateSelection(bool Selected, bool First = false)
	{
		//Selection.gameObject.SetActive(Selected);
		Selection.color = Selected ? (First ? ColorSelectedFirst : ColorSelected) : ColorNormal;
	}

	public void UpdateValues(int UnitCounts, int GroupCounts)
	{
		UnitsCount.text = GroupCounts + " - " + UnitCounts;
	}

	public void AddNew()
	{
		AddAction(this);
	}

	public void RemoveGroup()
	{
		RemoveAction(this);
	}

	public void OnGroupClick()
	{
		SelectAction(this);

	}

	public void OnExpandClick()
	{
		Source.Expanded = !Source.Expanded;
		IsExpanded = Source.Expanded;
		ExpandAction(this);
	}

	const float DoubleClickTime = 0.3f;
	float LastClickTime = 0;
	public void OnTitleClick()
	{

		if (IsRoot)
			return;

		if(Time.realtimeSinceStartup - LastClickTime < DoubleClickTime)
		{
			RenameStart();
		}


		LastClickTime = Time.realtimeSinceStartup;
	}


	void RenameStart()
	{
		SelectButton.SetActive(false);
		GroupName.gameObject.SetActive(false);
		Header.SetActive(false);
		RenameAction(this);
		Pivot.gameObject.SetActive(false);
	}

	public void RenameEnd()
	{
		SelectButton.SetActive(true);
		GroupName.gameObject.SetActive(true);
		Header.SetActive(true);
		Pivot.gameObject.SetActive(_expand);
	}


}
