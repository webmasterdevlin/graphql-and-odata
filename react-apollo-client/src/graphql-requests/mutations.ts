import { gql } from "@apollo/client";

export const CREATE_REVIEW = gql`
  mutation CreateReview($review: reviewInput!) {
    createReview(review: $review) {
      id
      title
      review
    }
  }
`;
