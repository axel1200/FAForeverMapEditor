﻿using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

using System.IO;
using System.IO.Compression;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.BZip2;


public partial class GetGamedataFile : MonoBehaviour
{

	static List<ScdZipFile> ScdFiles = new List<ScdZipFile>();

	public class ScdZipFile
	{
		public string scd;
		public ZipFile zf;
	}

	/// <summary>
	/// Loads bytes from *.scd files from game gamedata folder. Returns decompressed bytes of that file.
	/// </summary>
	/// <param name="scd"></param>
	/// <param name="LocalPath"></param>
	/// <returns></returns>
	public static byte[] LoadBytes(string scd, string LocalPath){
		if (string.IsNullOrEmpty(LocalPath)) return null;

		if (!Directory.Exists(EnvPaths.GetGamedataPath()))
		{
			Debug.LogError("Gamedata path not exist!");
			return null;
		}
		//byte[] FinalBytes = new byte[0];
		int ScdId = -1;

		for(int i = 0; i < ScdFiles.Count; i++)
		{
			if (ScdFiles[i].scd == scd)
			{
				ScdId = i;
				break;
			}
		}

		if(ScdId < 0)
		{
			ScdId = ScdFiles.Count;
			ScdZipFile NewScd = new ScdZipFile();
			NewScd.scd = scd;
			ScdFiles.Add(NewScd);

			FileStream fs = File.OpenRead(EnvPaths.GetGamedataPath() + scd);
			ScdFiles[ScdId].zf = new ZipFile(fs);
		}


		ZipEntry zipEntry2 = ScdFiles[ScdId].zf.GetEntry(LocalPath);
		if (zipEntry2 == null)
		{
			//Debug.LogWarning("Zip Entry is empty for: " + LocalPath);
			return null;
		}

		byte[] FinalBytes = new byte[4096]; // 4K is optimum

		if (zipEntry2 != null)
		{
			Stream s = ScdFiles[ScdId].zf.GetInputStream(zipEntry2);
			FinalBytes = new byte[zipEntry2.Size];
			s.Read(FinalBytes, 0, FinalBytes.Length);
			s.Close();
		}

		/*try
		{

			ZipEntry zipEntry2 = ScdFiles[ScdId].zf.GetEntry(LocalPath);
			if (zipEntry2 == null)
			{
				Debug.LogWarning("Zip Entry is empty for: " + LocalPath);
				return null;
			}

			FinalBytes = new byte[4096]; // 4K is optimum

			if (zipEntry2 != null)
			{
				Stream s = ScdFiles[ScdId].zf.GetInputStream(zipEntry2);
				FinalBytes = new byte[zipEntry2.Size];
				s.Read(FinalBytes, 0, FinalBytes.Length);
			}
		}
		finally
		{
			if (zf != null)
			{
				zf.IsStreamOwner = true; // Makes close also shut the underlying stream
				zf.Close(); // Ensure we release resources
			}
		}*/
		return FinalBytes;
	}

}
