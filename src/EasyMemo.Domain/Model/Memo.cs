﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool
//     Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace EasyMemo.Domain.Model
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

	public partial class Memo : AggregateRoot
	{
		public virtual string Title
		{
			get;
			set;
		}

		public virtual string Content
		{
			get;
			set;
		}

		public virtual DateTime DateAdded
		{
			get;
			set;
		}

		public virtual Nullable<DateTime> DateModified
		{
			get;
			set;
		}

	}
}
