using Elements;
using System.Collections.Generic;
using System;
using System.Linq;

namespace StreetsAndBlocks
{
	/// <summary>
	/// Override metadata for StreetsOverrideRemoval
	/// </summary>
	public partial class StreetsOverrideRemoval : IOverride
	{
        public static string Name = "Streets Removal";
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