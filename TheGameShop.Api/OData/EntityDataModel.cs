using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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