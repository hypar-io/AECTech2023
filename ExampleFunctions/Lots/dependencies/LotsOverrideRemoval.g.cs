using Elements;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Lots
{
	/// <summary>
	/// Override metadata for LotsOverrideRemoval
	/// </summary>
	public partial class LotsOverrideRemoval : IOverride
	{
        public static string Name = "Lots Removal";
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