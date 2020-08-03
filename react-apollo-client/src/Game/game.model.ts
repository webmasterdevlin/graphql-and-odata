export type GameModel = {
  id: number;
  name: string;
  price: number;
  rating: number;
  stock: number;
  reviews: ReviewModel[];
};

export type ReviewModel = {
  id: number;
  title: string;
  review: string;
};
