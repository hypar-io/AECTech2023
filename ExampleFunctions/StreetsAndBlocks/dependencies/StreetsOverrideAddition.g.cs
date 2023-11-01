using Elements;
using System.Collections.Generic;
using System;
using System.Linq;

namespace StreetsAndBlocks
{
	/// <summary>
	/// Override metadata for StreetsOverrideAddition
	/// </summary>
	public partial class StreetsOverrideAddition : IOverride
	{
        public static string Name = "Streets Addition";
        public static string Dependency = null;
        public static string Context = "[*discriminator=Elements.Street]";
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