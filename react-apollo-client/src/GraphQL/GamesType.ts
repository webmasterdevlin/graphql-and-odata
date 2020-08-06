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

export type GameModel = {
  id: number;
  name: string;
  price: number;
  rating: number;
  stock: number;
  photoFileName: string;
  developedBy: DeveloperModel[];
  publishedBy: PublisherModel[];
  genre: GenreModel[];
  reviews: ReviewModel[];
};

export type ReviewModel = {
  id: number;
  title: string;
  review: string;
};

export type DeveloperModel = {
  id: boolean;
  name: string;
};

export type PublisherModel = {
  id: boolean;
  name: string;
};

export type GenreModel = {
  id: boolean;
  type: string;
};
