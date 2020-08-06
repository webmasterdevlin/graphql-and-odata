import React from "react";
import { Routes, Route } from "react-router-dom";
import NotFound from "./NotFound";
import Dashboard from "./Dashboard/Dashboard";
import DashboardIndex from "./Dashboard/DashboardIndex";
import NavigationBar from "./components/navigation-bar";
import Games from "./Game/Games";
import GameDetails from "./Game/GameDetails";

type Props = {};

const Router: React.FC<Props> = () => {
  return (
    <>
      <NavigationBar />

      <Routes>
        <Route path="/" element={<Games />} />
        <Route path="/game-details/:id" element={<GameDetails />} />
        <Route path="dashboard" element={<Dashboard />}>
          <Route path="/" element={<DashboardIndex />} />
        </Route>
        <Route path="*" element={<NotFound />} />
      </Routes>
    </>
  );
};

export default Router;
