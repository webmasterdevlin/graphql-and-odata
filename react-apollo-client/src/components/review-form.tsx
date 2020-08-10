import React from "react";
import { Form, Formik } from "formik";
import { useMutation } from "@apollo/client";
import { Box, Button, TextField, Typography, Grid } from "@material-ui/core";
import * as Yup from "yup";
import { CREATE_REVIEW } from "../graphql-requests/mutations";

const ReviewForm: React.FC<any> = ({ id }) => {
  const [mutate, { data }] = useMutation(CREATE_REVIEW);

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
          initialValues={initialValue}
          validationSchema={validator}
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

const initialValue = { title: "", review: "" };
const validator = Yup.object({
  title: Yup.string(),
  review: Yup.string(),
});
