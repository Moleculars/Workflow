namespace Black.Beard.Core.Documents
{

    public interface ITypeReferential
    {

        /// <summary>
        /// Initializes with the specified configuration.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        void Initialize(VersionedConfigurationDocument configuration);

    }

}