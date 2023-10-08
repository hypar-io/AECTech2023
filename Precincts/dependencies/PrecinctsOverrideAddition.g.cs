using Elements;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Precincts
{
	/// <summary>
	/// Override metadata for PrecinctsOverrideAddition
	/// </summary>
	public partial class PrecinctsOverrideAddition : IOverride
	{
        public static string Name = "Precincts Addition";
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