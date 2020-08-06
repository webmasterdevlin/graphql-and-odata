import { InMemoryCache } from "@apollo/client";
import { GameModel } from "./GraphQL/GamesType";

export const cache: InMemoryCache = new InMemoryCache({
  typePolicies: {
    Query: {
      fields: {},
    },
  },
});

export const gameNamesVar = cache.makeVar<GameModel[]>([]);
