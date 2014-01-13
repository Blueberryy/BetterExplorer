﻿using BExplorer.Shell.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BExplorer.Shell
{
	public static class Defaults
	{
		public static void AddDefaultColumns(this ShellView shellView)
		{

			LVCOLUMN column = new LVCOLUMN();
			column.mask = LVCF.LVCF_FMT | LVCF.LVCF_TEXT | LVCF.LVCF_WIDTH | LVCF.LVCF_SUBITEM;
			column.cx = 100;
			column.iSubItem = 0;
			column.pszText = "Name";
			column.fmt = LVCFMT.LEFT;
			User32.SendMessage(shellView.LVHandle, BExplorer.Shell.Interop.MSG.LVM_INSERTCOLUMN, 0, ref column);

			shellView.Collumns.Add(column.ToCollumns(new PROPERTYKEY() { fmtid = Guid.Parse("B725F130-47EF-101A-A5F1-02608C9EEBAC"), pid = 10 }, typeof(String), false));


			LVCOLUMN column2 = new LVCOLUMN();
			column2.mask = LVCF.LVCF_FMT | LVCF.LVCF_TEXT | LVCF.LVCF_WIDTH | LVCF.LVCF_SUBITEM;
			column2.cx = 100;
			column2.iSubItem = 1;
			column2.pszText = "Type";
			column2.fmt = LVCFMT.LEFT;
			User32.SendMessage(shellView.LVHandle, BExplorer.Shell.Interop.MSG.LVM_INSERTCOLUMN, 1, ref column2);

			shellView.Collumns.Add(column2.ToCollumns(new PROPERTYKEY() { fmtid = Guid.Parse("B725F130-47EF-101A-A5F1-02608C9EEBAC"), pid = 4 }, typeof(String), false));


			LVCOLUMN column3 = new LVCOLUMN();
			column3.mask = LVCF.LVCF_FMT | LVCF.LVCF_TEXT | LVCF.LVCF_WIDTH | LVCF.LVCF_SUBITEM;
			column3.cx = 100;
			column3.iSubItem = 2;
			column3.pszText = "Size";
			column3.fmt = LVCFMT.RIGHT;
			User32.SendMessage(shellView.LVHandle, BExplorer.Shell.Interop.MSG.LVM_INSERTCOLUMN, 2, ref column3);

			shellView.Collumns.Add(column3.ToCollumns(new PROPERTYKEY() { fmtid = Guid.Parse("B725F130-47EF-101A-A5F1-02608C9EEBAC"), pid = 12 }, typeof(long), false));


			LVCOLUMN column4 = new LVCOLUMN();
			column4.mask = LVCF.LVCF_FMT | LVCF.LVCF_TEXT | LVCF.LVCF_WIDTH | LVCF.LVCF_SUBITEM;
			column4.cx = 100;
			column4.iSubItem = 3;
			column4.pszText = "Date Modified";
			column4.fmt = LVCFMT.LEFT;
			User32.SendMessage(shellView.LVHandle, BExplorer.Shell.Interop.MSG.LVM_INSERTCOLUMN, 3, ref column4);

			shellView.Collumns.Add(column4.ToCollumns(new PROPERTYKEY() { fmtid = Guid.Parse("B725F130-47EF-101A-A5F1-02608C9EEBAC"), pid = 14 }, typeof(DateTime), false));
		}

		public static Dictionary<String, Tuple<String, PROPERTYKEY, Type>> AllColumnsPKeys = new Dictionary<string, Tuple<String, PROPERTYKEY, Type>>()
		{
			{"A0", new Tuple<String, PROPERTYKEY, Type>("Name", new PROPERTYKEY(){fmtid = Guid.Parse("B725F130-47EF-101A-A5F1-02608C9EEBAC"), pid = 10}, typeof(String))},
			{"A1", new Tuple<String, PROPERTYKEY, Type>("Type", new PROPERTYKEY(){fmtid = Guid.Parse("B725F130-47EF-101A-A5F1-02608C9EEBAC"), pid = 4}, typeof(String))},
			{"A2", new Tuple<String, PROPERTYKEY, Type>("Size", new PROPERTYKEY(){fmtid = Guid.Parse("B725F130-47EF-101A-A5F1-02608C9EEBAC"), pid = 12}, typeof(long))},
			{"A3", new Tuple<String, PROPERTYKEY, Type>("Date Modified", new PROPERTYKEY(){fmtid = Guid.Parse("B725F130-47EF-101A-A5F1-02608C9EEBAC"), pid = 14}, typeof(DateTime))},
		};

		public static LVCOLUMN ToNativeColumn(this Collumns col)
		{
			LVCOLUMN column = new LVCOLUMN();
			column.mask = LVCF.LVCF_FMT | LVCF.LVCF_TEXT | LVCF.LVCF_WIDTH;
			column.cx = 100;
			column.pszText = col.Name;
			column.fmt = LVCFMT.LEFT;
			return column;
		}
		public static List<Collumns> AvailableColumns(this ShellView view)
		{
			return AllColumnsPKeys.Select(s => new Collumns(){ID = s.Key, CollumnType = s.Value.Item3, pkey = s.Value.Item2, Name = s.Value.Item1, Width = 100, IsColumnHandler = false }).ToList();
		}
	}
}
