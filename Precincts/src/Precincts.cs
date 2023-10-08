using Elements;
using Elements.Geometry;
using System.Collections.Generic;

namespace Precincts
{
  public static class Precincts
  {
    /// <summary>
    /// The Precincts function.
    /// </summary>
    /// <param name="model">The input model.</param>
    /// <param name="input">The arguments to the execution.</param>
    /// <returns>A PrecinctsOutputs instance containing computed results and the model with any new elements.</returns>
    public static PrecinctsOutputs Execute(Dictionary<string, Model> inputModels, PrecinctsInputs input)
    {
      // Your code here.
      var output = new PrecinctsOutputs();
      var sites = Site.CreateElements(input.Overrides);
      output.Model.AddElements(sites);
      return output;
    }
  }
}