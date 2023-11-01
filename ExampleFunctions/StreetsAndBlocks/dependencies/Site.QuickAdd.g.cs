using StreetsAndBlocks;
using Newtonsoft.Json;
namespace Elements
{
    public partial class Site
    {
        [JsonProperty("Add Id")]
        public string AddId { get; set; }

        /// <summary>
        /// Determine whether the provided identity is a match for this object. Auto-generated from the schema.
        /// ⚠️ Do not edit this method: it will be overwritten automatically next
        /// time you run 'hypar init'.
        /// </summary>
        public bool Match(BlocksIdentity identity)
        {
            return identity.AddId == this.AddId;
        }

        /// <summary>
        /// Set all properties of the element. Auto-generated from the schema.
        /// ⚠️ Do not edit this method: it will be overwritten automatically next
        /// time you run 'hypar init'.
        /// </summary>
        public void SetAllProperties(BlocksOverrideAddition add)
        {
            // Identity
            this.AddId = add.Id;
            // Properties
            this.Perimeter = add.Value.Perimeter;

        }

        /// <summary>
        /// Set all properties of the element. Auto-generated from the schema.
        /// ⚠️ Do not edit this method: it will be overwritten automatically next
        /// time you run 'hypar init'.
        /// </summary>
        public void SetAllProperties(BlocksOverride edit)
        {
            // Properties
            this.Perimeter = edit.Value.Perimeter;

        }
        
        public static List<Site> CreateElements(Overrides overrides, IEnumerable<Site> existingElements = null)
        {
            return overrides.Blocks.CreateElements(
                overrides.Additions.Blocks,
                overrides.Removals.Blocks,
                (add) => new Site(add),
                (elem, identity) => elem.Match(identity),
                (elem, edit) => { elem.Update(edit); return elem; },
                existingElements
            );
        } 
    }
}