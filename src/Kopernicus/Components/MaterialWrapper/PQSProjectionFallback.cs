// Material wrapper generated by shader translator tool

using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace Kopernicus.Components.MaterialWrapper
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
    [SuppressMessage("ReSharper", "MemberCanBeProtected.Global")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class PQSProjectionFallback : Material
    {
        // Internal property ID tracking object
        protected class Properties
        {
            // Return the shader for this wrapper
            private const String SHADER_NAME = "Terrain/PQS/Sphere Projection SURFACE QUAD (Fallback) ";

            public static Shader Shader
            {
                get { return Shader.Find(SHADER_NAME); }
            }

            // Saturation, default = 1
            public const String SATURATION_KEY = "_saturation";
            public Int32 SaturationId { get; private set; }

            // Contrast, default = 1
            public const String CONTRAST_KEY = "_contrast";
            public Int32 ContrastId { get; private set; }

            // Colour Unsaturation (A = Factor), default = (1,1,1,0)
            public const String TINT_COLOR_KEY = "_tintColor";
            public Int32 TintColorId { get; private set; }

            // Near Tiling, default = 1000
            public const String TEX_TILING_KEY = "_texTiling";
            public Int32 TexTilingId { get; private set; }

            // Near Blend, default = 0.5
            public const String TEX_POWER_KEY = "_texPower";
            public Int32 TexPowerId { get; private set; }

            // Far Blend, default = 0.5
            public const String MULTI_POWER_KEY = "_multiPower";
            public Int32 MultiPowerId { get; private set; }

            // NearFar Start, default = 2000
            public const String GROUND_TEX_START_KEY = "_groundTexStart";
            public Int32 GroundTexStartId { get; private set; }

            // NearFar Start, default = 10000
            public const String GROUND_TEX_END_KEY = "_groundTexEnd";
            public Int32 GroundTexEndId { get; private set; }

            // Multifactor, default = 0.5
            public const String MULTI_FACTOR_KEY = "_multiFactor";
            public Int32 MultiFactorId { get; private set; }

            // Main Texture, default = "white" { }
            public const String MAIN_TEX_KEY = "_mainTex";
            public Int32 MainTexId { get; private set; }

            // PlanetOpacity, default = 1
            public const String PLANET_OPACITY_KEY = "_PlanetOpacity";
            public Int32 PlanetOpacityId { get; private set; }

            // Singleton instance
            private static Properties _singleton;

            public static Properties Instance
            {
                get
                {
                    // Construct the singleton if it does not exist
                    return _singleton ?? (_singleton = new Properties());
                }
            }

            private Properties()
            {
                SaturationId = Shader.PropertyToID(SATURATION_KEY);
                ContrastId = Shader.PropertyToID(CONTRAST_KEY);
                TintColorId = Shader.PropertyToID(TINT_COLOR_KEY);
                TexTilingId = Shader.PropertyToID(TEX_TILING_KEY);
                TexPowerId = Shader.PropertyToID(TEX_POWER_KEY);
                MultiPowerId = Shader.PropertyToID(MULTI_POWER_KEY);
                GroundTexStartId = Shader.PropertyToID(GROUND_TEX_START_KEY);
                GroundTexEndId = Shader.PropertyToID(GROUND_TEX_END_KEY);
                MultiFactorId = Shader.PropertyToID(MULTI_FACTOR_KEY);
                MainTexId = Shader.PropertyToID(MAIN_TEX_KEY);
                PlanetOpacityId = Shader.PropertyToID(PLANET_OPACITY_KEY);
            }
        }

        // Is some random material this material 
        [SuppressMessage("ReSharper", "UnusedMember.Global")]
        public static Boolean UsesSameShader(Material m)
        {
            if (m == null)
            {
                return false;
            }

            return m.shader.name == Properties.Shader.name;
        }

        // Saturation, default = 1
        public Single Saturation
        {
            get { return GetFloat(Properties.Instance.SaturationId); }
            set { SetFloat(Properties.Instance.SaturationId, value); }
        }

        // Contrast, default = 1
        public Single Contrast
        {
            get { return GetFloat(Properties.Instance.ContrastId); }
            set { SetFloat(Properties.Instance.ContrastId, value); }
        }

        // Colour Unsaturation (A = Factor), default = (1,1,1,0)
        public Color TintColor
        {
            get { return GetColor(Properties.Instance.TintColorId); }
            set { SetColor(Properties.Instance.TintColorId, value); }
        }

        // Near Tiling, default = 1000
        public Single TexTiling
        {
            get { return GetFloat(Properties.Instance.TexTilingId); }
            set { SetFloat(Properties.Instance.TexTilingId, value); }
        }

        // Near Blend, default = 0.5
        public Single TexPower
        {
            get { return GetFloat(Properties.Instance.TexPowerId); }
            set { SetFloat(Properties.Instance.TexPowerId, value); }
        }

        // Far Blend, default = 0.5
        public Single MultiPower
        {
            get { return GetFloat(Properties.Instance.MultiPowerId); }
            set { SetFloat(Properties.Instance.MultiPowerId, value); }
        }

        // NearFar Start, default = 2000
        public Single GroundTexStart
        {
            get { return GetFloat(Properties.Instance.GroundTexStartId); }
            set { SetFloat(Properties.Instance.GroundTexStartId, value); }
        }

        // NearFar Start, default = 10000
        public Single GroundTexEnd
        {
            get { return GetFloat(Properties.Instance.GroundTexEndId); }
            set { SetFloat(Properties.Instance.GroundTexEndId, value); }
        }

        // Multifactor, default = 0.5
        public Single MultiFactor
        {
            get { return GetFloat(Properties.Instance.MultiFactorId); }
            set { SetFloat(Properties.Instance.MultiFactorId, value); }
        }

        // Main Texture, default = "white" { }
        public Texture2D MainTex
        {
            get { return GetTexture(Properties.Instance.MainTexId) as Texture2D; }
            set { SetTexture(Properties.Instance.MainTexId, value); }
        }

        public Vector2 MainTexScale
        {
            get { return GetTextureScale(Properties.Instance.MainTexId); }
            set { SetTextureScale(Properties.Instance.MainTexId, value); }
        }

        public Vector2 MainTexOffset
        {
            get { return GetTextureOffset(Properties.Instance.MainTexId); }
            set { SetTextureOffset(Properties.Instance.MainTexId, value); }
        }

        // PlanetOpacity, default = 1
        public Single PlanetOpacity
        {
            get { return GetFloat(Properties.Instance.PlanetOpacityId); }
            set { SetFloat(Properties.Instance.PlanetOpacityId, value); }
        }

        public PQSProjectionFallback() : base(Properties.Shader)
        {
        }

        [Obsolete("Creating materials from shader source String is no longer supported. Use Shader assets instead.")]
        public PQSProjectionFallback(String contents) : base(contents)
        {
            shader = Properties.Shader;
        }

        public PQSProjectionFallback(Material material) : base(material)
        {
            // Throw exception if this material was not the proper material
            if (material.shader.name != Properties.Shader.name)
            {
                throw new InvalidOperationException(
                    "Type Mismatch: Terrain/PQS/Sphere Projection SURFACE QUAD (Fallback)  shader required");
            }
        }

    }
}
