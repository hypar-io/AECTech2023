using Elements;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Precincts
{
	/// <summary>
	/// Override metadata for PrecinctsOverrideRemoval
	/// </summary>
	public partial class PrecinctsOverrideRemoval : IOverride
	{
        public static string Name = "Precincts Removal";
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