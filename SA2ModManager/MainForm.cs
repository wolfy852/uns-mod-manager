﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml.Serialization;
using IniSerializer;

namespace SA2ModManager
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		//const string datadllpath = @"resource\gd_PC\DLL\Win32\Data_DLL.dll";
		//const string datadllorigpath = @"resource\gd_PC\DLL\Win32\Data_DLL_orig.dll";
		const string loaderinipath = @"mods\UNSRModLoader.ini";
		//const string loaderdllpath = @"mods\SA2ModLoader.dll";
		LoaderInfo loaderini;
		Dictionary<string, ModInfo> mods;
        // Commented these out for now, since UNSR has no cheat codes.
		//const string codexmlpath = @"mods\Codes.xml";
		//const string codedatpath = @"mods\Codes.dat";
		//CodeList codes;
		//bool installed;
        bool modsactive;
        bool uselauncher;
        bool closeafterlaunch;

		private void MainForm_Load(object sender, EventArgs e)
		{
			Random rand = new Random();
			if (rand.Next(2) == 1)
				switch (rand.Next(7))
				{
					case 0:
						Icon = Properties.Resources.itachi;
						break;
					case 1:
						Icon = Properties.Resources.sasukeems;
						break;
					case 2:
						Icon = Properties.Resources.shisui;
						break;
					case 3:
						Icon = Properties.Resources.sharingan;
						break;
                    case 4:
                        Icon = Properties.Resources.kakashi;
                        break;
                    case 5:
                        Icon = Properties.Resources.madara;
                        break;
                    case 6:
                        Icon = Properties.Resources.sasuke;
                        break;
				}

			if (File.Exists(loaderinipath))
				loaderini = IniFile.Deserialize<LoaderInfo>(loaderinipath);
			else
				loaderini = new LoaderInfo();

			LoadModList();

            if (!launcherCheckBox.Checked)
                uselauncher = false;
            else
                uselauncher = true;

            if (!closeCheckBox.Checked)
                closeafterlaunch = false;
            else
                closeafterlaunch = true;

            string modfolder = Path.Combine(Environment.CurrentDirectory, "mods\\");
            foreach (ListViewItem mod in modListView.Items)
            {
                string[] allmods = Directory.GetDirectories(modfolder);
                string[] curfiles = Directory.GetFiles(modfolder + (allmods[mod.Index].Remove(0, modfolder.Length)));
                string[] cursubdirs = Directory.GetDirectories(modfolder + (allmods[mod.Index].Remove(0, modfolder.Length)));
                for (int i = 0; i < cursubdirs.Length; i++)
                {
                    if (Directory.Exists(cursubdirs[i].Remove(0, allmods[mod.Index].Length + 1)))
                    {
                        modsactive = true;
                        installButton.Text = "Disable Mods";
                    }
                    else
                    {
                        modsactive = false;
                        installButton.Text = "Enable Mods";
                    }
                }
            }

            #region loader stuff, not needed since the loading method is different for the UNS games
            /* if (!File.Exists(datadllpath))
			{
				MessageBox.Show(this, "Data_DLL.dll could not be found.\n\nCannot determine state of installation.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				installButton.Hide();
			}
			else if (File.Exists(datadllorigpath))
			{
				installed = true;
				installButton.Text = "Uninstall loader";
				MD5 md5 = MD5.Create();
				byte[] hash1 = md5.ComputeHash(File.ReadAllBytes(loaderdllpath));
				byte[] hash2 = md5.ComputeHash(File.ReadAllBytes(datadllpath));
				if (!hash1.SequenceEqual(hash2))
					if (MessageBox.Show(this, "Installed loader DLL differs from copy in mods folder.\n\nDo you want to overwrite the installed copy?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
						File.Copy(loaderdllpath, datadllpath, true);
            } 

            try { codes = CodeList.Load(codexmlpath); }
			catch { codes = new CodeList() { Codes = new List<Code>() }; }
			foreach (Code item in codes.Codes)
				codesCheckedListBox.Items.Add(item.Name, item.Enabled);*/
            #endregion

        }

		private void modListView_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (modListView.SelectedIndices.Count == 0)
			{
				modUpButton.Enabled = modDownButton.Enabled = false;
				modDescription.Text = "Description: No mod selected.";
			}
			else
			{
				modDescription.Text = "Description: " + mods[(string)modListView.SelectedItems[0].Tag].Description;
				modUpButton.Enabled = modListView.SelectedIndices[0] > 0;
				modDownButton.Enabled = modListView.SelectedIndices[0] < modListView.Items.Count - 1;
			}
		}

		private void modUpButton_Click(object sender, EventArgs e)
		{
			int i = modListView.SelectedIndices[0];
			ListViewItem item = modListView.Items[i];
			modListView.BeginUpdate();
			modListView.Items.Remove(item);
			modListView.Items.Insert(i - 1, item);
			modListView.EndUpdate();
		}

		private void modDownButton_Click(object sender, EventArgs e)
		{
			int i = modListView.SelectedIndices[0];
			ListViewItem item = modListView.Items[i];
			modListView.BeginUpdate();
			modListView.Items.Remove(item);
			modListView.Items.Insert(i + 1, item);
			modListView.EndUpdate();
		}

		private void modAboutButton_Click(object sender, EventArgs e)
		{
			ModInfo mod = mods[(string)modListView.SelectedItems[0].Tag];
			MessageBox.Show(this, string.Format("Name: {0}\nAuthor: {1}\nDescription: {2}", mod.Name, mod.Author, mod.Description), Text);
		}

		private void Save()
		{
			loaderini.Mods.Clear();
			foreach (ListViewItem item in modListView.CheckedItems)
				loaderini.Mods.Add((string)item.Tag);
			IniFile.Serialize(loaderini, loaderinipath);
            SetMods();

            #region old stuff for cheat codes
            /*for (int i = 0; i < codes.Codes.Count; i++)
				codes.Codes[i].Enabled = codesCheckedListBox.GetItemChecked(i);
			codes.Save(codexmlpath);
			using (FileStream fs = File.Create(codedatpath))
			using (BinaryWriter bw = new BinaryWriter(fs, System.Text.Encoding.ASCII))
			{
				bw.Write(new[] { 'c', 'o', 'd', 'e', 'v', '3' });
				bw.Write(codes.Codes.Count((a) => a.Enabled));
				foreach (Code item in codes.Codes.Where((a) => a.Enabled))
				{
					if (item.IsReg)
						bw.Write((byte)CodeType.newregs);
					WriteCodes(item.Lines, bw);
				}
				bw.Write(byte.MaxValue);
			}*/
		}

        /*private void WriteCodes(IEnumerable<CodeLine> codes, BinaryWriter writer)
        {
            foreach (CodeLine line in codes)
            {
                writer.Write((byte)line.Type);
                uint address;
                if (line.Address.StartsWith("r"))
                    address = uint.Parse(line.Address.Substring(1), System.Globalization.NumberStyles.None, System.Globalization.NumberFormatInfo.InvariantInfo);
                else
                    address = uint.Parse(line.Address, System.Globalization.NumberStyles.HexNumber);
                if (line.Pointer)
                    address |= 0x80000000u;
                writer.Write(address);
                if (line.Pointer)
                    if (line.Offsets != null)
                    {
                        writer.Write((byte)line.Offsets.Count);
                        foreach (int off in line.Offsets)
                            writer.Write(off);
                    }
                    else
                        writer.Write((byte)0);
                if (line.Type == CodeType.ifkbkey)
                    writer.Write((int)(Keys)Enum.Parse(typeof(Keys), line.Value));
                else
                    switch (line.ValueType)
                    {
                        case ValueType.@decimal:
                            switch (line.Type)
                            {
                                case CodeType.writefloat:
                                case CodeType.addfloat:
                                case CodeType.subfloat:
                                case CodeType.mulfloat:
                                case CodeType.divfloat:
                                case CodeType.ifeqfloat:
                                case CodeType.ifnefloat:
                                case CodeType.ifltfloat:
                                case CodeType.iflteqfloat:
                                case CodeType.ifgtfloat:
                                case CodeType.ifgteqfloat:
                                    writer.Write(float.Parse(line.Value, System.Globalization.NumberStyles.Float, System.Globalization.NumberFormatInfo.InvariantInfo));
                                    break;
                                default:
                                    writer.Write(unchecked((int)long.Parse(line.Value, System.Globalization.NumberStyles.Integer, System.Globalization.NumberFormatInfo.InvariantInfo)));
                                    break;
                            }
                            break;
                        case ValueType.hex:
                            writer.Write(uint.Parse(line.Value, System.Globalization.NumberStyles.HexNumber, System.Globalization.NumberFormatInfo.InvariantInfo));
                            break;
                    }
                writer.Write(line.RepeatCount ?? 1);
                if (line.IsIf)
                {
                    WriteCodes(line.TrueLines, writer);
                    if (line.FalseLines.Count > 0)
                    {
                        writer.Write((byte)CodeType.@else);
                        WriteCodes(line.FalseLines, writer);
                    }
                    writer.Write((byte)CodeType.endif);
                }
            }
        }*/
            #endregion

        private void saveAndPlayButton_Click(object sender, EventArgs e)
		{
            string launchexe;
            if (!uselauncher)
                launchexe = "NSUNSR.exe";
            else
                launchexe = "NSUNSR_launcher.exe";
			Save();
			System.Diagnostics.Process.Start(loaderini.Mods.Select((item) => mods[item].EXEFile)
				.FirstOrDefault((item) => !string.IsNullOrEmpty(item)) ?? launchexe);
            if (closeafterlaunch)
			    Close();
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			Save();
		}

		private void installButton_Click(object sender, EventArgs e)
		{
			if (modsactive)
			{
                ClearMods();
				installButton.Text = "Enable Mods";
			}
			else
			{
                SetMods();
				installButton.Text = "Disable Mods";
			}
			modsactive = !modsactive;
		}

        #region more old stuff for cheat codes
        /*private void codesCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (codesCheckedListBox.SelectedIndices.Count == 0)
				codeUpButton.Enabled = codeDownButton.Enabled = false;
			else
			{
				codeUpButton.Enabled = codesCheckedListBox.SelectedIndices[0] > 0;
				codeDownButton.Enabled = codesCheckedListBox.SelectedIndices[0] < codesCheckedListBox.Items.Count - 1;
			}
		}

		private void codeUpButton_Click(object sender, EventArgs e)
		{
			int i = codesCheckedListBox.SelectedIndices[0];
			Code code = codes.Codes[i];
			codes.Codes.Remove(code);
			codes.Codes.Insert(i - 1, code);
			object item = codesCheckedListBox.Items[i];
			codesCheckedListBox.BeginUpdate();
			codesCheckedListBox.Items.Remove(item);
			codesCheckedListBox.Items.Insert(i - 1, item);
			codesCheckedListBox.EndUpdate();
		}

		private void codeDownButton_Click(object sender, EventArgs e)
		{
			int i = codesCheckedListBox.SelectedIndices[0];
			Code code = codes.Codes[i];
			codes.Codes.Remove(code);
			codes.Codes.Insert(i + 1, code);
			object item = codesCheckedListBox.Items[i];
			codesCheckedListBox.BeginUpdate();
			codesCheckedListBox.Items.Remove(item);
			codesCheckedListBox.Items.Insert(i + 1, item);
			codesCheckedListBox.EndUpdate();
		}*/
        #endregion

        private void LoadModList()
		{
			mods = new Dictionary<string, ModInfo>();
			string modsfolder = Path.Combine(Environment.CurrentDirectory, "mods");
			foreach (string filename in Directory.GetFiles(modsfolder, "mod.ini", SearchOption.AllDirectories))
				mods.Add(Path.GetDirectoryName(filename).Remove(0, modsfolder.Length + 1), IniFile.Deserialize<ModInfo>(filename));
			modListView.BeginUpdate();
			foreach (string mod in new List<string>(loaderini.Mods))
			{
				if (mods.ContainsKey(mod))
				{
					ModInfo inf = mods[mod];
					modListView.Items.Add(new ListViewItem(new[] { inf.Name, inf.Author }) { Checked = true, Tag = mod });
				}
				else
				{
					MessageBox.Show(this, "Mod \"" + mod + "\" could not be found.\n\nThis mod will be removed from the list.", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					loaderini.Mods.Remove(mod);
				}
			}
			foreach (KeyValuePair<string, ModInfo> inf in mods)
				if (!loaderini.Mods.Contains(inf.Key))
					modListView.Items.Add(new ListViewItem(new[] { inf.Value.Name, inf.Value.Author }) { Tag = inf.Key });
			modListView.EndUpdate();
		}

        private void SetMods()
        {
            ClearMods();
            string modfolder = Path.Combine(Environment.CurrentDirectory, "mods\\");
            if (modsactive)
            {
                foreach (ListViewItem item in modListView.Items)
                {
                    if (item.Checked)
                        DirectoryCopy(modfolder + loaderini.Mods[item.Index], Directory.GetCurrentDirectory(), true);
                }
            }
        }

        private void ClearMods()
        {
            string modfolder = Path.Combine(Environment.CurrentDirectory, "mods\\");
            foreach (ListViewItem mod in modListView.Items)
            {
                string[] allmods = Directory.GetDirectories(modfolder);
                string[] curfiles = Directory.GetFiles(modfolder + (allmods[mod.Index].Remove(0, modfolder.Length)));
                string[] cursubdirs = Directory.GetDirectories(modfolder + (allmods[mod.Index].Remove(0, modfolder.Length)));
                for (int i = 0; i < cursubdirs.Length; i++)
                {
                    if (Directory.Exists(cursubdirs[i].Remove(0, allmods[mod.Index].Length + 1)))
                    {
                        Directory.Delete(cursubdirs[i].Remove(0, allmods[mod.Index].Length + 1), true);
                    }
                }
                for (int i = 0; i < curfiles.Length; i++)
                {
                    if (File.Exists(Path.GetFileName(curfiles[i])))
                    {
                        File.Delete(Path.GetFileName(curfiles[i]));
                    }
                }
            }
        }

		private void buttonRefreshModList_Click(object sender, EventArgs e)
		{
			modListView.Items.Clear();
			LoadModList();
		}

		private void buttonModsFolder_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(@"mods");
		}

		private void buttonNewMod_Click(object sender, EventArgs e)
		{
			using (var ModDialog = new NewModDialog())
			{
				if (ModDialog.ShowDialog() == DialogResult.OK)
				{
					modListView.Items.Clear();
					LoadModList();
				}
			}
		}

        private void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            // If the destination directory doesn't exist, create it. 
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                if (file.Name != "mod.ini")
                    file.CopyTo(temppath, true); // Boolean is set to true to allow File.CopyTo to overwrite any files already within the folder.
            }

            // If copying subdirectories, copy them and their contents to new location. 
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
	}

	class LoaderInfo
	{
		public bool DebugConsole { get; set; }
		public bool DebugScreen { get; set; }
		public bool DebugFile { get; set; }
		public bool? ShowConsole { get { return null; } set { if (value.HasValue) DebugConsole = value.Value; } }
		[IniName("Mod")]
		[IniCollection(IniCollectionMode.NoSquareBrackets, StartIndex = 1)]
		public List<string> Mods { get; set; }

		public LoaderInfo()
		{
			Mods = new List<string>();
		}
	}

	class ModInfo
	{
		public string Name { get; set; }
		public string Author { get; set; }
		public string Description { get; set; }
		public string EXEFile { get; set; }
		public string DLLFile { get; set; }
	}

	[XmlRoot(Namespace = "http://www.sonicretro.org")]

    #region code class, list, and types
    /*public class CodeList
	{
		static readonly XmlSerializer serializer = new XmlSerializer(typeof(CodeList));

		public static CodeList Load(string filename)
		{
			using (FileStream fs = File.OpenRead(filename))
				return (CodeList)serializer.Deserialize(fs);
		}

		public void Save(string filename)
		{
			using (FileStream fs = File.Create(filename))
				serializer.Serialize(fs, this);
		}

		[XmlElement("Code")]
		public List<Code> Codes { get; set; }
	}

	public class Code
	{
		[XmlAttribute("name")]
		public string Name { get; set; }
		[XmlAttribute("enabled")]
		public bool Enabled { get; set; }
		[XmlIgnore]
		public bool EnabledSpecified { get { return Enabled; } set { } }
		[XmlElement("CodeLine")]
		public List<CodeLine> Lines { get; set; }

		[XmlIgnore]
		public bool IsReg { get { return Lines.Any((line) => line.IsReg); } }
	}

	public class CodeLine
	{
		public CodeType Type { get; set; }
		[XmlElement(IsNullable = false)]
		public string Address { get; set; }
		public bool Pointer { get; set; }
		[XmlIgnore]
		public bool PointerSpecified { get { return Pointer; } set { } }
		[XmlIgnore]
		public List<int> Offsets { get; set; }
		[XmlArray("Offsets")]
		[XmlArrayItem("Offset")]
		public string[] OffsetStrings
		{
			get { return Offsets == null ? null : Offsets.Select((a) => a.ToString("X")).ToArray(); }
			set { Offsets = value.Select((a) => int.Parse(a, System.Globalization.NumberStyles.HexNumber)).ToList(); }
		}
		[XmlIgnore]
		public bool OffsetStringsSpecified { get { return Offsets != null && Offsets.Count > 0; } set { } }
		[XmlElement(IsNullable = false)]
		public string Value { get; set; }
		public ValueType ValueType { get; set; }
		public uint? RepeatCount { get; set; }
		[XmlIgnore]
		public bool RepeatCountSpecified { get { return RepeatCount.HasValue; } set { } }
		[XmlArray]
		public List<CodeLine> TrueLines { get; set; }
		[XmlIgnore]
		public bool TrueLinesSpecified { get { return TrueLines.Count > 0 && IsIf; } set { } }
		[XmlArray]
		public List<CodeLine> FalseLines { get; set; }
		[XmlIgnore]
		public bool FalseLinesSpecified { get { return FalseLines.Count > 0 && IsIf; } set { } }

		[XmlIgnore]
		public bool IsIf
		{
			get
			{
				return (Type >= CodeType.ifeq8 && Type <= CodeType.ifkbkey)
					|| (Type >= CodeType.ifeqreg8 && Type <= CodeType.ifmaskreg32);
			}
		}

		[XmlIgnore]
		public bool IsReg
		{
			get
			{
				if (IsIf)
				{
					if (TrueLines.Any((line) => line.IsReg))
						return true;
					if (FalseLines.Any((line) => line.IsReg))
						return true;
				}
				if (Address.StartsWith("r"))
					return true;
				if (Type >= CodeType.readreg8 && Type <= CodeType.ifmaskreg32)
					return true;
				return false;
			}
		}
	}

	public enum CodeType
	{
		write8, write16, write32, writefloat,
		add8, add16, add32, addfloat,
		sub8, sub16, sub32, subfloat,
		mulu8, mulu16, mulu32, mulfloat,
		muls8, muls16, muls32,
		divu8, divu16, divu32, divfloat,
		divs8, divs16, divs32,
		modu8, modu16, modu32,
		mods8, mods16, mods32,
		shl8, shl16, shl32,
		shru8, shru16, shru32,
		shrs8, shrs16, shrs32,
		rol8, rol16, rol32,
		ror8, ror16, ror32,
		and8, and16, and32,
		or8, or16, or32,
		xor8, xor16, xor32,
		ifeq8, ifeq16, ifeq32, ifeqfloat,
		ifne8, ifne16, ifne32, ifnefloat,
		ifltu8, ifltu16, ifltu32, ifltfloat,
		iflts8, iflts16, iflts32,
		ifltequ8, ifltequ16, ifltequ32, iflteqfloat,
		iflteqs8, iflteqs16, iflteqs32,
		ifgtu8, ifgtu16, ifgtu32, ifgtfloat,
		ifgts8, ifgts16, ifgts32,
		ifgtequ8, ifgtequ16, ifgtequ32, ifgteqfloat,
		ifgteqs8, ifgteqs16, ifgteqs32,
		ifmask8, ifmask16, ifmask32,
		ifkbkey,
		readreg8, readreg16, readreg32,
		writereg8, writereg16, writereg32,
		addreg8, addreg16, addreg32, addregfloat,
		subreg8, subreg16, subreg32, subregfloat,
		mulregu8, mulregu16, mulregu32, mulregfloat,
		mulregs8, mulregs16, mulregs32,
		divregu8, divregu16, divregu32, divregfloat,
		divregs8, divregs16, divregs32,
		modregu8, modregu16, modregu32,
		modregs8, modregs16, modregs32,
		shlreg8, shlreg16, shlreg32,
		shrregu8, shrregu16, shrregu32,
		shrregs8, shrregs16, shrregs32,
		rolreg8, rolreg16, rolreg32,
		rorreg8, rorreg16, rorreg32,
		andreg8, andreg16, andreg32,
		orreg8, orreg16, orreg32,
		xorreg8, xorreg16, xorreg32,
		ifeqreg8, ifeqreg16, ifeqreg32, ifeqregfloat,
		ifnereg8, ifnereg16, ifnereg32, ifneregfloat,
		ifltregu8, ifltregu16, ifltregu32, ifltregfloat,
		ifltregs8, ifltregs16, ifltregs32,
		iflteqregu8, iflteqregu16, iflteqregu32, iflteqregfloat,
		iflteqregs8, iflteqregs16, iflteqregs32,
		ifgtregu8, ifgtregu16, ifgtregu32, ifgtregfloat,
		ifgtregs8, ifgtregs16, ifgtregs32,
		ifgteqregu8, ifgteqregu16, ifgteqregu32, ifgteqregfloat,
		ifgteqregs8, ifgteqregs16, ifgteqregs32,
		ifmaskreg8, ifmaskreg16, ifmaskreg32,
		@else,
		endif,
		newregs
	}*/
    #endregion

    public enum ValueType
	{
		@decimal,
		hex
	}
}