using Elements;
using Elements.Geometry;
using Elements.Spatial;
using Elements.Triangulation;
using System.Collections.Generic;

namespace Lots
{
  public static class Lots
  {
    /// <summary>
    /// The Lots function.
    /// </summary>
    /// <param name="model">The input model.</param>
    /// <param name="input">The arguments to the execution.</param>
    /// <returns>A LotsOutputs instance containing computed results and the model with any new elements.</returns>
    public static LotsOutputs Execute(Dictionary<string, Model> inputModels, LotsInputs input)
    {
      // Your code here.
      var output = new LotsOutputs();
      var defaultLots = new List<Site>();
      if (inputModels.TryGetValue("Streets and Blocks", out var streetsAndBlocksModel))
      {
        foreach (var block in streetsAndBlocksModel.AllElementsOfType<Site>())
        {
            defaultLots.AddRange(block.CreateLots());
        }
      }
      var lots = Site.CreateElements(input.Overrides, defaultLots);
      output.Model.AddElements(lots);
      return output;
    }
  }
}