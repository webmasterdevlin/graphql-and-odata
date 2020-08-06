import React from "react";
import { Helmet } from "react-helmet";
import { BrowserRouter } from "react-router-dom";
import Router from "./Router";

function App() {
  return (
    <BrowserRouter>
      <Helmet>
        <meta charSet="utf-8" />
        <title>React Apollo Client v3</title>
        <link
          rel="stylesheet"
          href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap"
        />
        <link
          rel="stylesheet"
          href="https://fonts.googleapis.com/icon?family=Material+Icons"
        />
      </Helmet>
      <Router />
    </BrowserRouter>
  );
}

export default App;
