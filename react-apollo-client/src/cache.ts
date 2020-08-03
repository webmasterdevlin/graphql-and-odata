import { InMemoryCache, Reference } from "@apollo/client";
import { GameModel } from "./Game/game.model";

export const cache: InMemoryCache = new InMemoryCache({
  typePolicies: {
    Query: {
      fields: {},
    },
  },
});

export const gameNamesVar = cache.makeVar<GameModel[]>([]);
