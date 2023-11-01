using Elements;
using System;
using System.Linq;
using System.Collections.Generic;
using Elements.Geometry;
using Newtonsoft.Json;
using Elements.Geometry.Solids;
using Lots;
using Elements.Spatial;

namespace Elements
{
    // This portion of the Site class is yours to edit with your own element behaviors.
    public partial class Site
    {
        public Material BorderMaterial { get; set; }
        // Access properties of the element and construct a representation.
        public override void UpdateRepresentations()
        {
            // Replace this with your own representation logic.
            // this.Representation = new Extrude(this.Perimeter, 1, Vector3.ZAxis, false);
            var perimeterBumped = this.Perimeter.TransformedPolygon(new Transform(0, 0, 0.1));
            this.RepresentationInstances.AddRange(
                new[] {
                    new RepresentationInstance(new SolidRepresentation(new Lamina(perimeterBumped)), this.Material),
                    new RepresentationInstance(new CurveRepresentation(perimeterBumped, true), this.BorderMaterial)
                }
            );
        }

        /// <summary>
        /// Construct a new instance of the element.
        /// </summary>
        /// <param name="add">User input at add time.</param>
        public Site(LotsOverrideAddition add)
        {
            this.Name = "Lot";
            var col = new Color("#dfdfdf") { Alpha = 0.4 };
            this.Material = new Material("Lot", col);
            this.BorderMaterial = BuiltInMaterials.Black;

            this.BorderMaterial.EdgeDisplaySettings = new EdgeDisplaySettings
            {
                LineWidth = 3
            };
            this.SetAllProperties(add);
        }

        public Site(Polygon perimeter, string addId)
        {
            this.Name = "Lot";
            var col = new Color("#dfdfdf") { Alpha = 0.4 };
            this.Material = new Material("Lot", col);
            this.BorderMaterial = BuiltInMaterials.Black;
            this.BorderMaterial.EdgeDisplaySettings = new EdgeDisplaySettings
            {
                LineWidth = 3
            };
            this.Perimeter = perimeter;
            this.AddId = addId;
        }

        /// <summary>
        /// Update the element on a subsequent change.
        /// </summary>
        /// <param name="edit">User input at edit time.</param>
        public void Update(LotsOverride edit)
        {
            // Optionally customize this method.
            this.SetAllProperties(edit);
        }

        public IEnumerable<Site> CreateLots()
        {
            var list = new List<Site>();
            var edges = this.Perimeter.Segments();
            var points = new List<Vector3>();
            foreach (var edge in edges)
            {
                var grid = new Grid1d(edge);
                grid.DivideByApproximateLength(20);
                var cells = grid.GetCells();
                foreach (var cell in cells)
                {
                    var line = cell.GetCellGeometry() as Line;
                    points.Add(line!.PointAt(0.5));
                }
            }
            var polygons = Triangulation.Triangulation.ComputeVoronoiPolygons(points, this.Perimeter);
            for (int i = 0; i < polygons.Count; i++)
            {
                Profile? polygon = polygons[i];
                var centroid = polygon.Perimeter.Centroid();
                var addId = $"${centroid.X:0.00},{centroid.Y:0.00}";
                var site = new Site(polygon.Perimeter, addId);
                list.Add(site);
            }
            return list;
        }
    }
}