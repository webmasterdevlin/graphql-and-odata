import React from "react";
import { Field, Form, Formik } from "formik";
import { gql, useMutation } from "@apollo/client";
import { Box, Button, TextField, Typography, Grid } from "@material-ui/core";
import * as Yup from "yup";

const CREATE_REVIEW = gql`
  mutation CreateReview($review: reviewInput!) {
    createReview(review: $review) {
      id
      title
      review
    }
  }
`;

const ReviewForm: React.FC<any> = ({ id }) => {
  const [mutate, { data, error, loading }] = useMutation(CREATE_REVIEW);

  const handleClickButton = (values: any) => {
    mutate({
      variables: {
        review: {
          gameId: id,
          title: values.title,
          review: values.review,
        },
      },
    });
  };

  return (
    <Grid container spacing={3}>
      <Grid item xs={6}>
        <Formik
          initialValues={{ title: "", review: "" }}
          validationSchema={Yup.object({
            title: Yup.string(),
            review: Yup.string(),
          })}
          onSubmit={(values, actions) => {
            handleClickButton(values);
          }}
        >
          {(formikProps) => (
            <Form>
              <Box py={4}>
                <Typography variant={"h4"}>Write a Review</Typography>
                <Box my={4}>
                  <section style={{ marginBottom: "2rem" }}>
                    <TextField
                      id="title"
                      label="Title"
                      defaultValue={formikProps.values.title}
                      onChange={formikProps.handleChange}
                      variant="outlined"
                    />
                  </section>
                  <section>
                    <TextField
                      id="review"
                      label="Comment"
                      defaultValue={formikProps.values.review}
                      onChange={formikProps.handleChange}
                      variant="outlined"
                    />
                  </section>
                </Box>
              </Box>
              <Button type={"submit"} variant={"contained"} color={"primary"}>
                Send
              </Button>
            </Form>
          )}
        </Formik>
      </Grid>
      <Grid item xs={6}>
        <h3>{JSON.stringify(data, null, 2)}</h3>
      </Grid>
    </Grid>
  );
};

export default ReviewForm;
