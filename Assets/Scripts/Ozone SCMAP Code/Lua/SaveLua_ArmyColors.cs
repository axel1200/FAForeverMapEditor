﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MapLua
{
	public partial class SaveLua
	{

		static string[] ArmyColors = new string[]
		{
			"ff436eee",      // new blue1
			"FFe80a0a",      // Cybran red
			"ff616d7e",      // grey
			"fffafa00",      // new yellow
			"FFFF873E",      // Nomads orange
			"ffffffff",      // white
			"ff9161ff",      // purple
			"ffff88ff",      // pink
			"ff2e8b57",      // new green
			"FF2929e1",      // UEF blue
			"FF5F01A7",      // dark purple
			"ffff32ff",      // new fuschia
			"ffffbf80",      // lt orange
			"ffa79602",      // Sera golden
			"ffb76518",      // new brown
			"ff901427",      // dark red
			"FF2F4F4F",      // olive (dark green)
			"ff40bf40",      // mid green
			"ff66ffcc",      // aqua
			"ff9fd802",      // Order Green
		};

		public static Color GetArmyColor(int id)
		{
			Color ToReturn = Color.white;

			if (id < 0)
				id = 0;
			else if (id >= ArmyColors.Length)
				id = ArmyColors.Length - 1;

			if(ColorUtility.TryParseHtmlString("#" + ArmyColors[id].Remove(0, 2), out ToReturn))
			{

			}
			else
			{
				Debug.LogWarning("Can't parse color: " + ArmyColors[id]);
			}

			return ToReturn;
		}

	}
}
