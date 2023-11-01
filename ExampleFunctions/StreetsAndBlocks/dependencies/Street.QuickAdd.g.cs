using StreetsAndBlocks;
using Newtonsoft.Json;
namespace Elements
{
    public partial class Street
    {
        [JsonProperty("Add Id")]
        public string AddId { get; set; }

        /// <summary>
        /// Determine whether the provided identity is a match for this object. Auto-generated from the schema.
        /// ⚠️ Do not edit this method: it will be overwritten automatically next
        /// time you run 'hypar init'.
        /// </summary>
        public bool Match(StreetsIdentity identity)
        {
            return identity.AddId == this.AddId;
        }

        /// <summary>
        /// Set all properties of the element. Auto-generated from the schema.
        /// ⚠️ Do not edit this method: it will be overwritten automatically next
        /// time you run 'hypar init'.
        /// </summary>
        public void SetAllProperties(StreetsOverrideAddition add)
        {
            // Identity
            this.AddId = add.Id;
            // Properties
            this.Geometry = add.Value.Geometry;

        }

        /// <summary>
        /// Set all properties of the element. Auto-generated from the schema.
        /// ⚠️ Do not edit this method: it will be overwritten automatically next
        /// time you run 'hypar init'.
        /// </summary>
        public void SetAllProperties(StreetsOverride edit)
        {
            // Properties
            this.Geometry = edit.Value.Geometry;

        }
        
        public static List<Street> CreateElements(Overrides overrides, IEnumerable<Street> existingElements = null)
        {
            return overrides.Streets.CreateElements(
                overrides.Additions.Streets,
                overrides.Removals.Streets,
                (add) => new Street(add),
                (elem, identity) => elem.Match(identity),
                (elem, edit) => { elem.Update(edit); return elem; },
                existingElements
            );
        } 
    }
}