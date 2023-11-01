using Elements;
using Elements.Geometry;
using System.Collections.Generic;

namespace StreetsAndBlocks
{
  public static class StreetsAndBlocks
  {
    /// <summary>
    /// The StreetsAndBlocks function.
    /// </summary>
    /// <param name="model">The input model.</param>
    /// <param name="input">The arguments to the execution.</param>
    /// <returns>A StreetsAndBlocksOutputs instance containing computed results and the model with any new elements.</returns>
    public static StreetsAndBlocksOutputs Execute(Dictionary<string, Model> inputModels, StreetsAndBlocksInputs input)
    {
      // Your code here.
      var output = new StreetsAndBlocksOutputs();
      var automaticStreets = new List<Street>();
      if (inputModels.TryGetValue("Precinct", out var precincts))
      {
        automaticStreets.AddRange(precincts.AllElementsOfType<Site>().SelectMany(precinct => precinct.ComputeStreets()));
      }
      var streets = Street.CreateElements(input.Overrides, automaticStreets);
      Street.ComputeNetwork(streets);
      output.Model.AddElements(streets);
      var automaticBlocks = Street.ComputeBlocks(streets);
      var blocks = Site.CreateElements(input.Overrides, automaticBlocks);
      output.Model.AddElements(blocks);
      return output;
    }
  }
}