using Elements;
using System;
using System.Linq;
using System.Collections.Generic;
using Elements.Geometry;
using Newtonsoft.Json;
using Elements.Geometry.Solids;
using Precincts;

namespace Elements
{
    // This portion of the Site class is yours to edit with your own element behaviors.
    public partial class Site
    {
        // Access properties of the element and construct a representation.
        public override void UpdateRepresentations()
        {
            // Replace this with your own representation logic.
            var perimeterShifted = this.Perimeter.TransformedPolygon(new Transform(0,0,0.001));
            this.RepresentationInstances.Add(new RepresentationInstance(new CurveRepresentation(perimeterShifted, true), this.Material));
            this.RepresentationInstances.Add(new RepresentationInstance(new SolidRepresentation(new Lamina(perimeterShifted)), this.Material));
        }

        /// <summary>
        /// Construct a new instance of the element.
        /// </summary>
        /// <param name="add">User input at add time.</param>
        public Site(PrecinctsOverrideAddition add)
        {
            var color = new Color("Aqua") { Alpha = 0.1 };
            this.Material = new Material("Precinct", color)
            {
                EdgeDisplaySettings = new EdgeDisplaySettings
                {
                    LineWidth = 4,
                    DashMode = EdgeDisplayDashMode.ScreenUnits,
                    DashSize = 20,
                }
            };
            this.Name = "Precinct";
            // Optionally customize this method.
            this.SetAllProperties(add);
        }

        /// <summary>
        /// Update the element on a subsequent change.
        /// </summary>
        /// <param name="edit">User input at edit time.</param>
        public void Update(PrecinctsOverride edit)
        {
            // Optionally customize this method.
            this.SetAllProperties(edit);
        }
    }
}