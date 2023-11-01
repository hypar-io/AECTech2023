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
    // This portion of the Street class is yours to edit with your own element behaviors.
    public partial class Street
    {
        // Access properties of the element and construct a representation.
        public override void UpdateRepresentations()
        {
            if (this._computedGeometry == null)
            {
                return;
            }
            // Replace this with your own representation logic.
            // this.Representation = new Lamina(this._computedGeometry);
            this.RepresentationInstances = new List<RepresentationInstance> {
                new(new SolidRepresentation(new Lamina(this._computedGeometry)), this.Material),
            };
            this.RepresentationInstances.AddRange(this.GetStripeRepresentations());
        }

        public List<RepresentationInstance> GetStripeRepresentations()
        {
            var list = new List<RepresentationInstance>();
            var centerline = this.GetCenterline();
            var grid1d = new Grid1d(centerline.Segments().First().TransformedLine(new Transform(0, 0, 0.001)));
            grid1d.DivideByPattern(new[] { ("Stripe", 1.0), ("Gap", 0.5) });
            foreach (var cell in grid1d.GetCells())
            {
                if (cell.Type == "Stripe")
                {
                    var domain = cell.Domain;
                    Console.WriteLine(domain);

                    list.Add(new RepresentationInstance(new CurveRepresentation(cell.GetCellGeometry(), true), this.StripeMaterial));
                }
            }
            return list;
        }

        /// <summary>
        /// Construct a new instance of the element.
        /// </summary>
        /// <param name="add">User input at add time.</param>
        public Street(StreetsOverrideAddition add)
        {
            this.Material = new Material("street", Colors.Gray);
            this.StripeMaterial = new Material("Center stripe", Colors.White);
            this.SetAllProperties(add);
        }

        public Street(ThickenedPolyline geometry)
        {
            this.Material = new Material("street", Colors.Gray);
            this.StripeMaterial = new Material("Center stripe", Colors.White);
            this.Geometry = geometry;
        }

        public Polyline GetCenterline()
        {
            // TODO: support non-center aligned streets.
            return this.Geometry.Polyline;
        }

        /// <summary>
        /// Update the element on a subsequent change.
        /// </summary>
        /// <param name="edit">User input at edit time.</param>
        public void Update(StreetsOverride edit)
        {
            // Optionally customize this method.
            this.SetAllProperties(edit);
        }

        [JsonIgnore]
        private Profile _computedGeometry { get; set; }

        [JsonIgnore]
        public Material StripeMaterial { get; }

        public static void ComputeNetwork(IEnumerable<Street> streets)
        {
            var streetGeometry = streets.Select(s => s.Geometry).ToList();
            var pgons = ThickenedPolyline.GetPolygons(streetGeometry);
            for (int i = 0; i < streets.Count(); i++)
            {
                streets.ElementAt(i)._computedGeometry = pgons[i].offsetPolygon;
            }
        }

        public static List<Site> ComputeBlocks(IEnumerable<Street> streets)
        {
            var sites = new List<Site>();
            var profiles = Profile.UnionAll(streets.Select(s => s._computedGeometry));
            var allVoids = profiles.SelectMany(p => p.Voids).ToList();
            for (int i = 0; i < allVoids.Count; i++)
            {
                Polygon? voidCurve = allVoids[i];
                if (voidCurve is not null)
                {
                    // flip the curve since voids wind backwards.
                    sites.Add(new Site(voidCurve.Reversed(), $"Site {i}"));
                }
            }
            return sites;
        }
    }
}