using Elements;
using System;
using System.Linq;
using System.Collections.Generic;
using Elements.Geometry;
using Newtonsoft.Json;
using Elements.Geometry.Solids;
using StreetsAndBlocks;
using Elements.Spatial;

namespace Elements
{
    // This portion of the Site class is yours to edit with your own element behaviors.
    public partial class Site
    {
        // Access properties of the element and construct a representation.
        public override void UpdateRepresentations()
        {
            // Replace this with your own representation logic.
            this.Representation = new Lamina(this.Perimeter);
        }

        public Site(Polygon perimeter, string addId)
        {
            this.Material = new Material("site", Colors.Green);
            this.Perimeter = perimeter;
            this.AddId = addId;
        }

        /// <summary>
        /// Construct a new instance of the element.
        /// </summary>
        /// <param name="add">User input at add time.</param>
        public Site(BlocksOverrideAddition add)
        {
            this.Material = new Material("site", Colors.Green);
            // Optionally customize this method.
            this.SetAllProperties(add);
        }

        /// <summary>
        /// Update the element on a subsequent change.
        /// </summary>
        /// <param name="edit">User input at edit time.</param>
        public void Update(BlocksOverride edit)
        {
            // Optionally customize this method.
            this.SetAllProperties(edit);
        }

        public List<Street> ComputeStreets()
        {
            var streets = new List<Street>();
            // a small offset so that grid lines aren't exactly at perimeter vertices.
            var perimOffset = this.Perimeter.Offset(1);
            var grid = new Grid2d(perimOffset);
            grid.U.DivideByApproximateLength(120);
            grid.V.DivideByApproximateLength(120);
            var uSeparators = grid.GetCellSeparators(GridDirection.U);
            var vSeparators = grid.GetCellSeparators(GridDirection.V);
            foreach (var segment in uSeparators.OfType<Line>())
            {
                var trimmedSegment = segment.Trim(this.Perimeter, out var _);
                foreach (var ts in trimmedSegment)
                {
                    if (ts.Length() < 10) continue;
                    streets.Add(new Street(new ThickenedPolyline(new Polyline(ts.Start, ts.End), 10, 10))
                    {
                        AddId = this.AddId + ts.Start.ToString() + ts.End.ToString()
                    });
                }
            }
            foreach (var segment in vSeparators.OfType<Line>())
            {
                var trimmedSegment = segment.Trim(this.Perimeter, out var _);
                foreach (var ts in trimmedSegment)
                {
                    if (ts.Length() < 10) continue;

                    streets.Add(new Street(new ThickenedPolyline(new Polyline(ts.Start, ts.End), 10, 10))
                    {
                        AddId = this.AddId + ts.Start.ToString() + ts.End.ToString()
                    });
                }
            }
            foreach (var segment in this.Perimeter.Segments())
            {
                streets.Add(new Street(new ThickenedPolyline(new Polyline(segment.Start, segment.End), 10, 10))
                {
                    AddId = this.AddId + segment.Start.ToString() + segment.End.ToString()
                });
            }
            return streets;
        }
    }
}