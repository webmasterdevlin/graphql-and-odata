import { GameModel } from "../models/game.model";

export type GamesType = {
  games: Array<GameModel>;
  loading: boolean;
  error: any;
};

export type GameType = {
  game: GameModel;
  loading: boolean;
  error: any;
};
