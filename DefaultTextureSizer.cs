using UnityEditor;

namespace pure_unity_methods
{
    public class DefaultTextureSizer : AssetPostprocessor
    {
        private const bool CompressTextures = true;
        private const int MaxTextureSize = 512;
    
        private static readonly string[] AssetPathsExemptFromCompression = { "Cards" , "" };

        private void OnPreprocessTexture()
        {
            if (!CompressTextures) return;
        
            var importer = assetImporter as TextureImporter;
        
            if (importer == null) return;
        
            if (!ShouldCompress(importer.assetPath)) return;

            if (importer.maxTextureSize > MaxTextureSize)
            {
                importer.maxTextureSize = MaxTextureSize;
            }
        }

        private static bool ShouldCompress(string assetPath)
        {
            foreach (var exemptPath in AssetPathsExemptFromCompression)
            {
                if (assetPath.Contains(exemptPath)) return false;
            }
            return true;
        }
    }
}