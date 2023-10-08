using Elements;
using System.Collections.Generic;
using System;
using System.Linq;

namespace StreetsAndBlocks
{
	/// <summary>
	/// Override metadata for BlocksOverrideAddition
	/// </summary>
	public partial class BlocksOverrideAddition : IOverride
	{
        public static string Name = "Blocks Addition";
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