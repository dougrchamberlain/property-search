// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutoMapperConfig.cs" company="">
//   
// </copyright>
// <summary>
//   The auto mapper config.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Search.Helpers.AutoMapper
{
    using global::AutoMapper;

    /// <summary>
    /// The auto mapper config.
    /// </summary>
    public class AutoMapperConfig
    {
        #region Public Methods and Operators

        /// <summary>
        /// The configure.
        /// </summary>
        public static void Configure()
        {
            Mapper.Initialize(x => x.AddProfile<ViewModelProfile>());
        }

        #endregion
    }
}