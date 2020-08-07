using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;
using TheGamesShop.Core.Entities;

namespace TheGameShop.Api.OData
{
    public static class EntityDataModel
    {
        /* EDM (Entity Data Model)*/

        public static IEdmModel GetEdmModel()
        {
            var edmBuilder = new ODataConventionModelBuilder();
            edmBuilder.EntitySet<Game>("Games");

            return edmBuilder.GetEdmModel();
        }
    }
}