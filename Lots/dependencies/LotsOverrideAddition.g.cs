using Elements;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Lots
{
	/// <summary>
	/// Override metadata for LotsOverrideAddition
	/// </summary>
	public partial class LotsOverrideAddition : IOverride
	{
        public static string Name = "Lots Addition";
        public static string Dependency = null;
        public static string Context = "[*discriminator=Elements.Site]";
		public static string Paradigm = "Edit";

        /// <summary>
        /// Get the override name for this override.
        /// </summary>
        public string GetName() {
			return Name;
		}

		public object GetIdentity() {

			return Identity;
		}

	}

}