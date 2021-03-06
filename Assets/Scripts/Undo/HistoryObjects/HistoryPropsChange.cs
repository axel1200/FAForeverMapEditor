﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UndoHistory;
using EditMap;

namespace UndoHistory
{
	public class HistoryPropsChange : HistoryObject
	{

		Dictionary<PropsInfo.PropTypeGroup, HashSet<Prop>> Groups;

		public override void Register(HistoryParameter Param)
		{
			Groups = new Dictionary<PropsInfo.PropTypeGroup, HashSet<Prop>>();

			foreach (PropsInfo.PropTypeGroup Grp in PropsInfo.AllPropsTypes)
			{
				HashSet<Prop> OldProps = new HashSet<Prop>(Grp.PropsInstances);

				Groups.Add(Grp, OldProps);
			}
		}


		public override void DoUndo()
		{
			if (!RedoGenerated)
				Undo.RegisterRedo(new HistoryPropsChange());
			RedoGenerated = true;
			DoRedo();
		}

		public override void DoRedo()
		{
			Selection.SelectionManager.Current.CleanSelection();

			foreach (KeyValuePair<PropsInfo.PropTypeGroup, HashSet<Prop>> Grp in Groups)
			{
				Grp.Key.SetNewInstances(Grp.Value);
			}

			Undo.Current.EditMenu.ChangeCategory(6);
			PropsInfo.Current.ShowTab(1);
		}
	}
}