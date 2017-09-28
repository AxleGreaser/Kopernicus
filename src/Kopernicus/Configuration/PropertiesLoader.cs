/**
 * Kopernicus Planetary System Modifier
 * ------------------------------------------------------------- 
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 3 of the License, or (at your option) any later version.
 *
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston,
 * MA 02110-1301  USA
 * 
 * This library is intended to be used as a plugin for Kerbal Space Program
 * which is copyright 2011-2017 Squad. Your usage of Kerbal Space Program
 * itself is governed by the terms of its EULA, not the license above.
 * 
 * https://kerbalspaceprogram.com
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace Kopernicus
{
    namespace Configuration
    {
        // Edit the CelestialBody component
        [RequireConfigType(ConfigType.Node)]
        public class PropertiesLoader : BaseLoader, IParserEventSubscriber
        {
            // Celestial body to edit
            public CelestialBody celestialBody { get; set; }

            // Body description
            [ParserTarget("description")]
            public String description
            {
                get { return celestialBody.bodyDescription; }
                set { celestialBody.bodyDescription = value; }
            }

            // Radius
            [ParserTarget("radius")]
            public NumericParser<Double> radius
            {
                get { return celestialBody.Radius; }
                set { celestialBody.Radius = value; }
            }

            // GeeASL
            [ParserTarget("geeASL")]
            public NumericParser<Double> geeASL
            {
                get { return celestialBody.GeeASL; }
                set { celestialBody.GeeASL = value; }
            }

            // Mass
            [ParserTarget("mass")]
            public NumericParser<Double> mass
            {
                get { return celestialBody.Mass; }
                set { celestialBody.Mass = value; hasMass = true; }
            }
            private Boolean hasMass = false;

            // Grav Param
            [ParserTarget("gravParameter")]
            public NumericParser<Double> gravParameter
            {
                get { return celestialBody.gravParameter; }
                set { celestialBody.gMagnitudeAtCenter = celestialBody.gravParameter = value; hasGravParam = true; }
            }
            private Boolean hasGravParam = false;

            // Does the body rotate?
            [ParserTarget("rotates")]
            public NumericParser<Boolean> rotates
            {
                get { return celestialBody.rotates; }
                set { celestialBody.rotates = value; }
            }

            // Rotation period of the world
            [ParserTarget("rotationPeriod")]
            public NumericParser<Double> rotationPeriod
            {
                get { return celestialBody.rotationPeriod; }
                set { celestialBody.rotationPeriod = value; }
            }

            // Is the body tidally locked to its parent?
            [ParserTarget("tidallyLocked")]
            public NumericParser<Boolean> tidallyLocked
            {
                get { return celestialBody.tidallyLocked; }
                set { celestialBody.tidallyLocked = value; }
            }

            // Initial rotation of the world
            [ParserTarget("initialRotation")]
            public NumericParser<Double> initialRotation
            {
                get { return celestialBody.initialRotation; }
                set { celestialBody.initialRotation = value; }
            }

            // Altitude where the Game switches the reference frame
            [ParserTarget("inverseRotThresholdAltitude")]
            public NumericParser<Single> inverseRotThresholdAltitude
            {
                get { return celestialBody.inverseRotThresholdAltitude; }
                set { celestialBody.inverseRotThresholdAltitude = value; }
            }

            // albedo
            [ParserTarget("albedo")]
            public NumericParser<Double> albedo
            {
                get { return celestialBody.albedo; }
                set { celestialBody.albedo = value; }
            }

            // emissivity
            [ParserTarget("emissivity")]
            public NumericParser<Double> emissivity
            {
                get { return celestialBody.emissivity; }
                set { celestialBody.emissivity = value; }
            }

            // coreTemperatureOffset
            [ParserTarget("coreTemperatureOffset")]
            public NumericParser<Double> coreTemperatureOffset
            {
                get { return celestialBody.coreTemperatureOffset; }
                set { celestialBody.coreTemperatureOffset = value; }
            }

            // Is this the home world
            [ParserTarget("isHomeWorld")]
            public NumericParser<Boolean> isHomeWorld
            {
                get { return celestialBody.isHomeWorld; }
                set { celestialBody.isHomeWorld = value; }
            }

            // Time warp altitude limits
            [ParserTarget("timewarpAltitudeLimits")]
            public NumericCollectionParser<Single> timewarpAltitudeLimits
            {
                get { return celestialBody.timeWarpAltitudeLimits != null ? celestialBody.timeWarpAltitudeLimits : new Single[0]; }
                set { celestialBody.timeWarpAltitudeLimits = value.value.ToArray(); }
            }

            // Sphere of Influence
            [ParserTarget("sphereOfInfluence")]
            public NumericParser<Double> sphereOfInfluence
            {
                get { return celestialBody.Has("sphereOfInfluence") ? celestialBody.Get<Double>("sphereOfInfluence") : celestialBody.sphereOfInfluence; }
                set { celestialBody.sphereOfInfluence = value; celestialBody.Set("sphereOfInfluence", value.value); }
            }

            // Hill Sphere
            [ParserTarget("hillSphere")]
            public NumericParser<Double> hillSphere
            {
                get { return celestialBody.Has("hillSphere") ? celestialBody.Get<Double>("hillSphere") : celestialBody.hillSphere; }
                set { celestialBody.hillSphere = value; celestialBody.Set("hillSphere", value.value); }
            }

            // solarRotationPeriod
            [ParserTarget("solarRotationPeriod")]
            public NumericParser<Boolean> solarRotationPeriod
            {
                get { return celestialBody.solarRotationPeriod; }
                set { celestialBody.solarRotationPeriod = value; }
            }

            // navballSwitchRadiusMult
            [ParserTarget("navballSwitchRadiusMult")]
            public NumericParser<Double> navballSwitchRadiusMult
            {
                get { return celestialBody.navballSwitchRadiusMult; }
                set { celestialBody.navballSwitchRadiusMult = value; }
            }
            // navballSwitchRadiusMult
            [ParserTarget("navballSwitchRadiusMultLow")]
            public NumericParser<Double> navballSwitchRadiusMultLow
            {
                get { return celestialBody.navballSwitchRadiusMultLow; }
                set { celestialBody.navballSwitchRadiusMultLow = value; }
            }

            // Science values of this body
            [ParserTarget("ScienceValues", allowMerge = true)]
            public ScienceValuesLoader scienceValues { get; set; }

            // Biomes of this body
            [PreApply]
            [ParserTargetCollection("Biomes", nameSignificance = NameSignificance.None)]
            public List<BiomeLoader> biomes = new List<BiomeLoader>();

            // Biome definition via MapSO parser
            [ParserTarget("biomeMap")]
            public MapSOParser_RGB<CBAttributeMapSO> biomeMap
            {
                get { return celestialBody.BiomeMap; }
                set
                {
                    if (((CBAttributeMapSO)value) != null)
                    {
                        celestialBody.BiomeMap = value;
                        celestialBody.BiomeMap.exactSearch = false;
                        celestialBody.BiomeMap.nonExactThreshold = 0.05f;
                    }
                }
            }

            // Threshold for Biomes
            [ParserTarget("nonExactThreshold")]
            public NumericParser<Single> nonExactThreshold
            {
                get { return celestialBody.BiomeMap != null ? celestialBody.BiomeMap.nonExactThreshold : 0.05f; }
                set { celestialBody.BiomeMap.nonExactThreshold = value; }
            }

            // If the biome threshold should get used
            [ParserTarget("exactSearch")]
            public NumericParser<Boolean> exactSearch
            {
                get { return celestialBody.BiomeMap != null ? celestialBody.BiomeMap.exactSearch : false; }
                set { celestialBody.BiomeMap.exactSearch = value; }
            }

            // If the body name should be prefixed with "the" in some situations
            [ParserTarget("useTheInName")]
            public NumericParser<Boolean> useTheInName
            {
                get { return celestialBody.bodyDisplayName.StartsWith("The", StringComparison.InvariantCultureIgnoreCase); }
                set { celestialBody.bodyDisplayName = "The " + celestialBody.bodyName; }
            }

            [ParserTarget("displayName")]
            public String displayName
            {
                get { return celestialBody.bodyDisplayName; }
                set { celestialBody.bodyDisplayName = value; }
            }

            // If the body should be unselectable
            [ParserTarget("selectable")]
            public NumericParser<Boolean> selectable
            {
                get { return !celestialBody.Has("notSelectable"); }
                set { if (!value.value) celestialBody.Set("notSelectable", true); }
            }

            // If the body should be hidden in RD
            [ParserTarget("RDVisibility")]
            public EnumParser<RDVisibility> hiddenRD
            {
                get
                {
                    if (celestialBody.Has("hiddenRnD"))
                        return celestialBody.Get<RDVisibility>("hiddenRnD");
                    return RDVisibility.VISIBLE;
                }
                set { celestialBody.Set("hiddenRnD", value.value); }
            }

            // If the body should be hidden in RnD
            [ParserTarget("RnDVisibility")]
            public EnumParser<RDVisibility> hiddenRnD
            {
                get
                {
                    if (celestialBody.Has("hiddenRnD"))
                        return celestialBody.Get<RDVisibility>("hiddenRnD");
                    return RDVisibility.VISIBLE;
                }
                set { celestialBody.Set("hiddenRnD", value.value); }
            }

            // If the body should rotate in RnD
            [ParserTarget("RnDRotation")]
            public NumericParser<bool> RnDRotation
            {
                get
                {
                    if (celestialBody.Has("RnDRotation"))
                        return celestialBody.Get<bool>("RnDRotation");
                    return celestialBody?.scaledBody?.GetComponentInChildren<SunCoronas>(true) != null;
                }
                set { celestialBody.Set("RnDRotation", value.value); }
            }

            // How visible should the planet be in the science archives
            public enum RDVisibility
            {
                VISIBLE,
                NOICON,
                HIDDEN,
                SKIP
            }

            // Max Zoom limit for TrackingStation and MapView
            // set the number of meters that can fit in the full height of the screen
            [ParserTarget("maxZoom")]
            public NumericParser<Single> minDistance
            {
                get { return celestialBody.Has("maxZoom") ? celestialBody.Get<Single>("maxZoom") : 10 * 6000f; }
                set { celestialBody.Set("maxZoom", value.value / 6000f); }
            }

            // Apply Event
            void IParserEventSubscriber.Apply(ConfigNode node)
            {
                // We require a science values object
                if (celestialBody.scienceValues == null)
                    celestialBody.scienceValues = new CelestialBodyScienceParams();

                // Create the science values cache
                scienceValues = new ScienceValuesLoader(celestialBody.scienceValues);

                // Event
                Events.OnPropertiesLoaderApply.Fire(this, node);
            }

            // PostApply Event
            void IParserEventSubscriber.PostApply(ConfigNode node)
            {
                // Replace biomes
                if (celestialBody.Has("removeBiomes") && celestialBody.Get<Boolean>("removeBiomes"))
                    celestialBody.BiomeMap.Attributes = new CBAttributeMapSO.MapAttribute[] { };

                if (biomes?.Count() > 0)
                {
                    // Check biome map
                    if (biomeMap?.value == null)
                        throw new InvalidOperationException("The Biome Map cannot be null if you want to add biomes.");

                    // Generate a list of biomes
                    List<CBAttributeMapSO.MapAttribute> biomesList = new List<CBAttributeMapSO.MapAttribute>();

                    // If removeBiomes is false we want to keep the original biomes
                    if (celestialBody.Has("removeBiomes") && !celestialBody.Get<Boolean>("removeBiomes"))
                        biomesList = celestialBody.BiomeMap.Attributes.ToList();

                    // Add the new biomes
                    biomesList.AddRange(biomes.Select(b => b.attribute));

                    // Replace the old biomes list with the new one
                    celestialBody.BiomeMap.Attributes = biomesList.ToArray();
                }

                // Converters
                if (hasGravParam)
                    GravParamToOthers();
                else if (hasMass)
                    MassToOthers();
                else
                    GeeASLToOthers();

                // Debug the fields (TODO - remove)
                Utility.DumpObjectFields(celestialBody.scienceValues, " Science Values ");
                if (celestialBody.BiomeMap != null)
                {
                    foreach (CBAttributeMapSO.MapAttribute biome in celestialBody.BiomeMap.Attributes)
                    {
                        Logger.Active.Log("Found Biome: " + biome.name + " : " + biome.mapColor + " : " + biome.value);
                    }
                }

                // TODO - tentative fix, needs to be able to be configured (if it can be?)
                if (celestialBody.progressTree == null)
                {
                    celestialBody.progressTree = new KSPAchievements.CelestialBodySubtree(celestialBody);
                    Logger.Active.Log("Added Progress Tree");
                }

                // Event
                Events.OnPropertiesLoaderPostApply.Fire(this, node);
            }

            /// <summary>
            /// Creates a new Properties Loader from the Injector context.
            /// </summary>
            public PropertiesLoader()
            {
                // Is this the parser context?
                if (generatedBody == null)
                    throw new InvalidOperationException("Must be executed in Injector context.");

                // Store values
                celestialBody = generatedBody.celestialBody;
            }

            /// <summary>
            /// Creates a new Properties Loader from a spawned CelestialBody.
            /// </summary>
            public PropertiesLoader(CelestialBody body)
            {
                // Is this a spawned body?
                if (body?.scaledBody == null)
                    throw new InvalidOperationException("The body must be already spawned by the PSystemManager.");

                // Store values
                celestialBody = body;
            }

            /// <summary>
            /// Creates a new Properties Loader from a custom PSystemBody.
            /// </summary>
            public PropertiesLoader(PSystemBody body)
            {
                // Set generatedBody
                if (body == null)
                    throw new InvalidOperationException("The body cannot be null.");
                generatedBody = body;

                // Store values
                celestialBody = generatedBody.celestialBody;
            }

            // Mass converters
            public void GeeASLToOthers()
            {
                Double rsq = celestialBody.Radius;
                rsq *= rsq;
                celestialBody.gMagnitudeAtCenter = celestialBody.GeeASL * 9.80665 * rsq;
                celestialBody.gravParameter = celestialBody.gMagnitudeAtCenter;
                celestialBody.Mass = celestialBody.gravParameter * (1 / 6.67408E-11);
                Logger.Active.Log("Via surface G, set gravParam to " + celestialBody.gravParameter + ", mass to " + celestialBody.Mass);
            }

            // Converts mass to Gee ASL using a body's radius.
            public void MassToOthers()
            {
                Double rsq = celestialBody.Radius;
                rsq *= rsq;
                celestialBody.GeeASL = celestialBody.Mass * (6.67408E-11 / 9.80665) / rsq;
                celestialBody.gMagnitudeAtCenter = celestialBody.GeeASL * 9.80665 * rsq;
                celestialBody.gravParameter = celestialBody.gMagnitudeAtCenter;
                Logger.Active.Log("Via mass, set gravParam to " + celestialBody.gravParameter + ", surface G to " + celestialBody.GeeASL);
            }

            // Convert gravParam to mass and GeeASL
            public void GravParamToOthers()
            {
                Double rsq = celestialBody.Radius;
                rsq *= rsq;
                celestialBody.Mass = celestialBody.gravParameter * (1 / 6.67408E-11);
                celestialBody.GeeASL = celestialBody.gravParameter / 9.80665 / rsq;
                celestialBody.gMagnitudeAtCenter = celestialBody.gravParameter;
                Logger.Active.Log("Via gravParam, set mass to " + celestialBody.Mass + ", surface G to " + celestialBody.GeeASL);
            }
        }
    }
}