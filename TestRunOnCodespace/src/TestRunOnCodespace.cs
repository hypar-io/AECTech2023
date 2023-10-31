using Elements;
using Elements.Geometry;
using System.Collections.Generic;

namespace TestRunOnCodespace
{
      public static class TestRunOnCodespace
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model">The input model.</param>
        /// <param name="input">The arguments to the execution.</param>
        /// <returns>A TestRunOnCodespaceOutputs instance containing computed results and the model with any new elements.</returns>
        public static TestRunOnCodespaceOutputs Execute(Dictionary<string, Model> inputModels, TestRunOnCodespaceInputs input)
        {
            // Your code here.
            var output = new TestRunOnCodespaceOutputs();

            // Gather inputs.
            var dfgdg = input.Dfgdg;

            return output;
        }
      }
}