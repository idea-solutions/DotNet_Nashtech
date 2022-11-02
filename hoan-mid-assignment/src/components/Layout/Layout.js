import * as React from "react";
import { Route, Routes } from "react-router-dom";
import Home from "../../pages/Home/Home";
import Login from "../../pages/Login/Login";
import Logout from "../../pages/Logout/Logout";
import Posts from "../../pages/Posts/Posts";
import Navbar from "../Navbar/Navbar";

const Layout = () => {
    return (
        <Routes>
            <Route element={<Navbar />}>
                <Route path={"/"} element={<Home />} />
                <Route path={"/posts"} element={<Posts />} />
                <Route path={"/profile"} element={<Posts />} />
                <Route path={"/login"} element={<Login />} />
                <Route path={"/logout"} element={<Logout />} />
            </Route>
        </Routes>
    );
};

export default Layout;
