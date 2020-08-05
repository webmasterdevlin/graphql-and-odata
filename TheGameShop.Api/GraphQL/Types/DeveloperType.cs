using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Instrumentation;
using GraphQL.Types;
using TheGamesShop.Core.Entities;

namespace TheGameShop.Api.GraphQL.Types
{
    public class DeveloperType : ObjectGraphType<Developer>
    {
        public DeveloperType()
        {
            Field(t => t.Id);
            Field(t => t.Name);
        }
    }
}